using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_7
{
    internal class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Add(T data)
        {
            if (root == null)
            {
                root = new TreeNode<T>(data);
            }
            else
            {
                AddChild(root, data);
            }
        }

        private void AddChild(TreeNode<T> node, T data)
        {
            if (data.CompareTo(node.Data) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode<T>(data) { Parent = node };
                }
                else
                {
                    AddChild(node.Left, data);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new TreeNode<T>(data) { Parent = node };
                }
                else
                {
                    AddChild(node.Right, data);
                }
            }
        }

        // Методы для получения следующего и предыдущего узла (для итератора)
        public TreeNode<T> Next(TreeNode<T> node)
        {
            if (node == null) return null;

            if (node.Right != null)
            {
                node = node.Right;
                while (node.Left != null)
                    node = node.Left;
                return node;
            }

            while (node.Parent != null && node == node.Parent.Right)
                node = node.Parent;

            return node.Parent;
        }

        public TreeNode<T> Previous(TreeNode<T> node)
        {
            if (node == null) return null;

            if (node.Left != null)
            {
                node = node.Left;
                while (node.Right != null)
                    node = node.Right;
                return node;
            }

            while (node.Parent != null && node == node.Parent.Left)
                node = node.Parent;

            return node.Parent;
        }

        // Основной итератор
        public IEnumerator<T> GetEnumerator()
        {
            TreeNode<T> current = GetMostLeftNode(root);
            while (current != null)
            {
                yield return current.Data;
                current = Next(current);
            }
        }

        // Обратный итератор
        public IEnumerable<T> GetReverseEnumerator()
        {
            TreeNode<T> current = GetMostRightNode(root);
            while (current != null)
            {
                yield return current.Data;
                current = Previous(current);
            }
        }

        private TreeNode<T> GetMostLeftNode(TreeNode<T> node)
        {
            while (node?.Left != null)
                node = node.Left;
            return node;
        }

        private TreeNode<T> GetMostRightNode(TreeNode<T> node)
        {
            while (node?.Right != null)
                node = node.Right;
            return node;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // Прямой обход - вывод в порядке добавления элементов в дерево
        public IEnumerable<T> GetPreOrderEnumerable()
        {
            if (root == null) yield break;

            var stack = new Stack<TreeNode<T>>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Data;

                if (node.Right != null) stack.Push(node.Right);
                if (node.Left != null) stack.Push(node.Left);
            }
        }

        // Обратный обход
        public IEnumerable<T> GetPostOrderEnumerable()
        {
            if (root == null) yield break;

            var stack1 = new Stack<TreeNode<T>>();
            var stack2 = new Stack<TreeNode<T>>();
            stack1.Push(root);

            while (stack1.Count > 0)
            {
                var node = stack1.Pop();
                stack2.Push(node);

                if (node.Left != null) stack1.Push(node.Left);
                if (node.Right != null) stack1.Push(node.Right);
            }

            while (stack2.Count > 0)
            {
                yield return stack2.Pop().Data;
            }
        }
    }
}
