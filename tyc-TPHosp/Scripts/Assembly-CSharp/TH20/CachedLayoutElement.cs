using UnityEngine;
using UnityEngine.EventSystems;

namespace TH20
{
	[ExecuteInEditMode]
	public class CachedLayoutElement : UIBehaviour
	{
		private bool _isDirty = true;

		public bool IsDirty
		{
			get
			{
				return _isDirty;
			}
			set
			{
				_isDirty = value;
			}
		}

		protected override void OnEnable()
		{
			_isDirty = true;
		}

		protected override void OnDisable()
		{
			_isDirty = true;
		}

		protected override void OnRectTransformDimensionsChange()
		{
			_isDirty = true;
		}
	}
}
