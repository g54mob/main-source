using NGenerics.Util;

namespace NGenerics.Patterns.Visitor
{
	public class OrderedVisitor<T> : IVisitor<T>
	{
		private readonly IVisitor<T> visitorToUse;

		public bool HasCompleted
		{
			get
			{
				return visitorToUse.HasCompleted;
			}
		}

		public IVisitor<T> VisitorToUse
		{
			get
			{
				return visitorToUse;
			}
		}

		public OrderedVisitor(IVisitor<T> visitorToUse)
		{
			Guard.ArgumentNotNull(visitorToUse, "visitorToUse");
			this.visitorToUse = visitorToUse;
		}

		public virtual void VisitPreOrder(T obj)
		{
			visitorToUse.Visit(obj);
		}

		public virtual void VisitPostOrder(T obj)
		{
			visitorToUse.Visit(obj);
		}

		public virtual void VisitInOrder(T obj)
		{
			visitorToUse.Visit(obj);
		}

		public void Visit(T obj)
		{
			visitorToUse.Visit(obj);
		}
	}
}
