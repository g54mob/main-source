using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Material", order = 2000)]
	public class MaterialVar : ScriptableVar
	{
		[SerializeField]
		private Material value;

		public Material Value
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

		public virtual void SetValue(MaterialVar var)
		{
			Value = var.Value;
		}

		public virtual void SetValue(Material var)
		{
			Value = var;
		}
	}
}
