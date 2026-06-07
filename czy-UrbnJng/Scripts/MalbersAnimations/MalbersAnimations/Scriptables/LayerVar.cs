using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Layer Mask", order = 2000)]
	public class LayerVar : ScriptableVar
	{
		[SerializeField]
		private LayerMask value = 0;

		public virtual LayerMask Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
			}
		}

		public static implicit operator int(LayerVar reference)
		{
			return reference.Value;
		}
	}
}
