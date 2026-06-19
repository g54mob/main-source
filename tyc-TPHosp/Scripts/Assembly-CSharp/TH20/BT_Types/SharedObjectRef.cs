using System;
using BehaviorDesigner.Runtime;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedObjectRef<RefClass, ObjClass> : SharedVariable<RefClass> where RefClass : ObjectRef<ObjClass>
	{
		public ObjClass Get => base.Value.Get;

		public bool IsValid()
		{
			if (base.Value != null)
			{
				return base.Value.IsValid();
			}
			return false;
		}
	}
}
