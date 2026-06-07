using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public sealed class DrinkSlot : ItemSlot
	{
		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		private MeshRenderer _meshRenderer;

		protected override void OnAwake()
		{
			base.OnAwake();
			SetMeshActive(value: false);
		}

		protected override void OnSetUsed(Item item)
		{
			base.OnSetUsed(item);
			SetMeshActive(value: true);
		}

		public void SetMeshActive(bool value)
		{
			_meshRenderer.gameObject.SetActive(value);
		}

		protected override void OnSetUnused()
		{
			base.OnSetUnused();
			SetMeshActive(value: false);
		}

		public override void ClearSlot()
		{
			if ((bool)base.InSlot)
			{
				base.InSlot.Clear();
			}
		}
	}
}
