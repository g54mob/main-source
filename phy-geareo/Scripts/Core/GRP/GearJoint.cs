namespace GRP
{
	public abstract class GearJoint
	{
		public IGear gearA;

		public IGear gearB;

		public GearContact contact;

		public virtual void Update()
		{
		}

		public virtual void Destroy()
		{
		}

		public virtual void OnDrawGizmos()
		{
		}
	}
}
