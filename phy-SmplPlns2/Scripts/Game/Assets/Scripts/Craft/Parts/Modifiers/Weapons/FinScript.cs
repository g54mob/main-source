using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class FinScript : PartModifierScript
	{
		[SerializeField]
		private float _duration = 0.5f;

		[SerializeField]
		private float _endAngle;

		public void ExtendFins()
		{
			base.transform.DOLocalRotate(new Vector3(_endAngle, 0f, 0f), _duration);
		}
	}
}
