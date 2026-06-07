using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[CreateAssetMenu(menuName = "Malbers Animations/Modifier/Mode/Attack Aligner")]
	public class MAttackAligner : ModeModifier
	{
		public FloatReference FindRadius = new FloatReference(5f);

		public FloatReference AlignTime = new FloatReference(0.15f);

		public LayerReference Layer = new LayerReference(-1);

		public override void OnModeEnter(Mode mode)
		{
			MAnimal animal = mode.Animal;
			Collider[] array = Physics.OverlapSphere(animal.Center, FindRadius, Layer.Value);
			Collider collider = null;
			float num = float.MaxValue;
			Collider[] array2 = array;
			foreach (Collider collider2 in array2)
			{
				if (!collider2.transform.SameHierarchy(animal.transform))
				{
					float num2 = Vector3.Distance(animal.Center, collider2.transform.position);
					if (num > num2)
					{
						num = num2;
						collider = collider2;
					}
				}
			}
			if ((bool)collider)
			{
				animal.StartCoroutine(MTools.AlignLookAtTransform(animal.transform, collider.transform, AlignTime));
			}
		}
	}
}
