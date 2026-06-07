using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Color", order = 2000)]
	public class ColorVar : ScriptableVar
	{
		[SerializeField]
		private Color value = Color.white;

		public virtual Color Value
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

		public virtual void SetValue(ColorVar var)
		{
			Value = var.Value;
		}

		public static implicit operator Color(ColorVar reference)
		{
			return reference.Value;
		}
	}
}
