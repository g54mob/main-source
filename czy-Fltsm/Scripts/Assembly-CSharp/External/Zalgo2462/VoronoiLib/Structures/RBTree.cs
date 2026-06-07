namespace External.Zalgo2462.VoronoiLib.Structures
{
	public class RBTree<T>
	{
		public RBTreeNode<T> Root { get; private set; }

		public RBTreeNode<T> InsertSuccessor(RBTreeNode<T> node, T successorData)
		{
			RBTreeNode<T> rBTreeNode = new RBTreeNode<T>
			{
				Data = successorData
			};
			RBTreeNode<T> rBTreeNode2;
			if (node != null)
			{
				rBTreeNode.Previous = node;
				rBTreeNode.Next = node.Next;
				if (node.Next != null)
				{
					node.Next.Previous = rBTreeNode;
				}
				node.Next = rBTreeNode;
				if (node.Right != null)
				{
					node = GetFirst(node.Right);
					node.Left = rBTreeNode;
				}
				else
				{
					node.Right = rBTreeNode;
				}
				rBTreeNode2 = node;
			}
			else if (Root != null)
			{
				node = GetFirst(Root);
				rBTreeNode.Next = node;
				node.Previous = rBTreeNode;
				node.Left = rBTreeNode;
				rBTreeNode2 = node;
			}
			else
			{
				Root = rBTreeNode;
				rBTreeNode2 = null;
			}
			rBTreeNode.Parent = rBTreeNode2;
			rBTreeNode.Red = true;
			node = rBTreeNode;
			while (rBTreeNode2 != null && rBTreeNode2.Red)
			{
				RBTreeNode<T> parent = rBTreeNode2.Parent;
				if (rBTreeNode2 == parent.Left)
				{
					RBTreeNode<T> right = parent.Right;
					if (right != null && right.Red)
					{
						rBTreeNode2.Red = false;
						right.Red = false;
						parent.Red = true;
						node = parent;
					}
					else
					{
						if (node == rBTreeNode2.Right)
						{
							RotateLeft(rBTreeNode2);
							node = rBTreeNode2;
							rBTreeNode2 = node.Parent;
						}
						rBTreeNode2.Red = false;
						parent.Red = true;
						RotateRight(parent);
					}
				}
				else
				{
					RBTreeNode<T> right = parent.Left;
					if (right != null && right.Red)
					{
						rBTreeNode2.Red = false;
						right.Red = false;
						parent.Red = true;
						node = parent;
					}
					else
					{
						if (node == rBTreeNode2.Left)
						{
							RotateRight(rBTreeNode2);
							node = rBTreeNode2;
							rBTreeNode2 = node.Parent;
						}
						rBTreeNode2.Red = false;
						parent.Red = true;
						RotateLeft(parent);
					}
				}
				rBTreeNode2 = node.Parent;
			}
			Root.Red = false;
			return rBTreeNode;
		}

		public void RemoveNode(RBTreeNode<T> node)
		{
			if (node.Next != null)
			{
				node.Next.Previous = node.Previous;
			}
			if (node.Previous != null)
			{
				node.Previous.Next = node.Next;
			}
			RBTreeNode<T> rBTreeNode = node.Parent;
			RBTreeNode<T> left = node.Left;
			RBTreeNode<T> right = node.Right;
			RBTreeNode<T> rBTreeNode2 = ((left == null) ? right : ((right != null) ? GetFirst(right) : left));
			if (rBTreeNode != null)
			{
				if (rBTreeNode.Left == node)
				{
					rBTreeNode.Left = rBTreeNode2;
				}
				else
				{
					rBTreeNode.Right = rBTreeNode2;
				}
			}
			else
			{
				Root = rBTreeNode2;
			}
			bool red;
			if (left != null && right != null)
			{
				red = rBTreeNode2.Red;
				rBTreeNode2.Red = node.Red;
				rBTreeNode2.Left = left;
				left.Parent = rBTreeNode2;
				if (rBTreeNode2 != right)
				{
					rBTreeNode = rBTreeNode2.Parent;
					rBTreeNode2.Parent = node.Parent;
					node = rBTreeNode2.Right;
					rBTreeNode.Left = node;
					rBTreeNode2.Right = right;
					right.Parent = rBTreeNode2;
				}
				else
				{
					rBTreeNode2.Parent = rBTreeNode;
					rBTreeNode = rBTreeNode2;
					node = rBTreeNode2.Right;
				}
			}
			else
			{
				red = node.Red;
				node = rBTreeNode2;
			}
			if (node != null)
			{
				node.Parent = rBTreeNode;
			}
			if (red)
			{
				return;
			}
			if (node != null && node.Red)
			{
				node.Red = false;
				return;
			}
			RBTreeNode<T> rBTreeNode3 = null;
			while (node != Root)
			{
				if (node == rBTreeNode.Left)
				{
					rBTreeNode3 = rBTreeNode.Right;
					if (rBTreeNode3.Red)
					{
						rBTreeNode3.Red = false;
						rBTreeNode.Red = true;
						RotateLeft(rBTreeNode);
						rBTreeNode3 = rBTreeNode.Right;
					}
					if ((rBTreeNode3.Left != null && rBTreeNode3.Left.Red) || (rBTreeNode3.Right != null && rBTreeNode3.Right.Red))
					{
						if (rBTreeNode3.Right == null || !rBTreeNode3.Right.Red)
						{
							rBTreeNode3.Left.Red = false;
							rBTreeNode3.Red = true;
							RotateRight(rBTreeNode3);
							rBTreeNode3 = rBTreeNode.Right;
						}
						rBTreeNode3.Red = rBTreeNode.Red;
						RBTreeNode<T> rBTreeNode4 = rBTreeNode;
						bool red2 = (rBTreeNode3.Right.Red = false);
						rBTreeNode4.Red = red2;
						RotateLeft(rBTreeNode);
						node = Root;
						break;
					}
				}
				else
				{
					rBTreeNode3 = rBTreeNode.Left;
					if (rBTreeNode3.Red)
					{
						rBTreeNode3.Red = false;
						rBTreeNode.Red = true;
						RotateRight(rBTreeNode);
						rBTreeNode3 = rBTreeNode.Left;
					}
					if ((rBTreeNode3.Left != null && rBTreeNode3.Left.Red) || (rBTreeNode3.Right != null && rBTreeNode3.Right.Red))
					{
						if (rBTreeNode3.Left == null || !rBTreeNode3.Left.Red)
						{
							rBTreeNode3.Right.Red = false;
							rBTreeNode3.Red = true;
							RotateLeft(rBTreeNode3);
							rBTreeNode3 = rBTreeNode.Left;
						}
						rBTreeNode3.Red = rBTreeNode.Red;
						RBTreeNode<T> rBTreeNode5 = rBTreeNode;
						bool red2 = (rBTreeNode3.Left.Red = false);
						rBTreeNode5.Red = red2;
						RotateRight(rBTreeNode);
						node = Root;
						break;
					}
				}
				rBTreeNode3.Red = true;
				node = rBTreeNode;
				rBTreeNode = rBTreeNode.Parent;
				if (node.Red)
				{
					break;
				}
			}
			if (node != null)
			{
				node.Red = false;
			}
		}

		public static RBTreeNode<T> GetFirst(RBTreeNode<T> node)
		{
			if (node == null)
			{
				return null;
			}
			while (node.Left != null)
			{
				node = node.Left;
			}
			return node;
		}

		public static RBTreeNode<T> GetLast(RBTreeNode<T> node)
		{
			if (node == null)
			{
				return null;
			}
			while (node.Right != null)
			{
				node = node.Right;
			}
			return node;
		}

		private void RotateLeft(RBTreeNode<T> node)
		{
			RBTreeNode<T> right = node.Right;
			RBTreeNode<T> parent = node.Parent;
			if (parent != null)
			{
				if (parent.Left == node)
				{
					parent.Left = right;
				}
				else
				{
					parent.Right = right;
				}
			}
			else
			{
				Root = right;
			}
			right.Parent = parent;
			node.Parent = right;
			node.Right = right.Left;
			if (node.Right != null)
			{
				node.Right.Parent = node;
			}
			right.Left = node;
		}

		private void RotateRight(RBTreeNode<T> node)
		{
			RBTreeNode<T> left = node.Left;
			RBTreeNode<T> parent = node.Parent;
			if (parent != null)
			{
				if (parent.Left == node)
				{
					parent.Left = left;
				}
				else
				{
					parent.Right = left;
				}
			}
			else
			{
				Root = left;
			}
			left.Parent = parent;
			node.Parent = left;
			node.Left = left.Right;
			if (node.Left != null)
			{
				node.Left.Parent = node;
			}
			left.Right = node;
		}
	}
}
