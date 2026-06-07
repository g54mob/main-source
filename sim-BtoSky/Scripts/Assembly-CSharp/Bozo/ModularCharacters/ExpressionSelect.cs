using System;
using UnityEngine;
using UnityEngine.Events;

namespace Bozo.ModularCharacters
{
	public class ExpressionSelect : MonoBehaviour
	{
		public OutfitSystem outfitSystem;

		public Animator animator;

		public string parameterID;

		private void OnEnable()
		{
			OutfitSystem obj = outfitSystem;
			obj.OnOutfitChanged = (UnityAction<Outfit>)Delegate.Combine(obj.OnOutfitChanged, new UnityAction<Outfit>(GetHead));
		}

		private void GetHead(Outfit outfit)
		{
			Outfit outfit2 = outfitSystem.GetOutfit("Head");
			if ((bool)outfit2)
			{
				animator = outfit2.GetComponentInChildren<Animator>();
			}
		}

		private void OnDisable()
		{
			OutfitSystem obj = outfitSystem;
			obj.OnOutfitChanged = (UnityAction<Outfit>)Delegate.Remove(obj.OnOutfitChanged, new UnityAction<Outfit>(GetHead));
		}

		public void SetExpression(float value)
		{
			animator.SetFloat(parameterID, value);
		}
	}
}
