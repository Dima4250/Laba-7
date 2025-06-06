using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_7
{
    public class TreeNode<T>
    {
        public TreeNode(T data)
        {
            this.Data = data;
        }

        public TreeNode<T> Parent { get; set; }
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }
}
