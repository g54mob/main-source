using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Jundroo.Common.Pool;

namespace Assets.Scripts.Craft.Parts.Modifiers.CarverParts
{
	public abstract class MeshModifierBaseData : PartModifierData
	{
		public event Action OnShapeChanged;

		public MeshModifierBaseData(XElement element)
			: base(element)
		{
		}

		public virtual void SyncSymmetricParts()
		{
			if (base.SymmetryDisabled)
			{
				return;
			}
			List<PartData> value;
			using (CollectionPool<List<PartData>, PartData>.Get(out value))
			{
				base.Part.PartScript.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(base.Part, value);
				foreach (PartData item in value)
				{
					if (item.TryGetModifier<TrapezoidMeshModifierData>(out var result))
					{
						SyncSymmetricModifier(result);
					}
				}
			}
		}

		protected void RaiseOnShapeChanged()
		{
			this.OnShapeChanged?.Invoke();
		}

		protected virtual void SyncSymmetricModifier(MeshModifierBaseData modifier)
		{
		}
	}
}
