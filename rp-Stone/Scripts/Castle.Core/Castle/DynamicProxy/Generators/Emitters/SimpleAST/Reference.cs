using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public abstract class Reference
	{
		protected Reference owner = SelfReference.Self;

		public Reference OwnerReference
		{
			get
			{
				return owner;
			}
			set
			{
				owner = value;
			}
		}

		protected Reference()
		{
		}

		protected Reference(Reference owner)
		{
			this.owner = owner;
		}

		public abstract void LoadAddressOfReference(ILGenerator gen);

		public abstract void LoadReference(ILGenerator gen);

		public abstract void StoreReference(ILGenerator gen);

		public virtual void Generate(ILGenerator gen)
		{
		}

		public virtual Expression ToAddressOfExpression()
		{
			return new AddressOfReferenceExpression(this);
		}

		public virtual Expression ToExpression()
		{
			return new ReferenceExpression(this);
		}
	}
}
