using UnityEngine;

namespace MalbersAnimations.Controller
{
	[CreateAssetMenu(menuName = "Malbers Animations/Modifier/Mode/Directional Damage")]
	public class MDirectionalDamage : ModeModifier
	{
		public enum HitDirection
		{
			TwoSides = 0,
			FourSides = 1,
			SixSides = 2
		}

		[Header("Damage Abilities")]
		public HitDirection hitDirection = HitDirection.SixSides;

		[Hide("hitDirection", new int[] { 2 })]
		public int FrontRight = 4;

		public int Right = 2;

		[Hide("hitDirection", new int[] { 2 })]
		public int BackRight = 5;

		[Hide("hitDirection", new int[] { 2 })]
		public int FrontLeft = 3;

		public int Left = 1;

		[Hide("hitDirection", new int[] { 2 })]
		public int BackLeft = 6;

		[Hide("hitDirection", new int[] { 1 })]
		public int Front = 3;

		[Hide("hitDirection", new int[] { 1 })]
		public int Back = 4;

		public bool debug;

		public override void OnModeEnter(Mode mode)
		{
			MAnimal animal = mode.Animal;
			Vector3 vector = animal.GetComponent<IMDamage>().HitDirection;
			if (vector == Vector3.zero)
			{
				return;
			}
			vector = -Vector3.ProjectOnPlane(vector, animal.UpVector);
			float num = Vector3.Angle(animal.Forward, vector);
			bool flag = Vector3.Dot(animal.Right, vector) < 0f;
			Color blue = Color.blue;
			float num2 = 2f;
			int abilityIndex = -99;
			float duration = 3f;
			switch (hitDirection)
			{
			case HitDirection.TwoSides:
				abilityIndex = (flag ? Left : Right);
				if (debug)
				{
					Debug.DrawRay(animal.transform.position, animal.transform.forward * num2, blue, duration);
					Debug.DrawRay(animal.transform.position, -animal.transform.forward * num2, blue, duration);
					Debug.DrawRay(animal.transform.position, Quaternion.Euler(0f, num * (float)((!flag) ? 1 : (-1)), 0f) * animal.transform.forward * num2, Color.red, duration);
				}
				break;
			case HitDirection.FourSides:
				if (num <= 45f)
				{
					abilityIndex = Front;
				}
				else if (num >= 45f && num <= 135f)
				{
					abilityIndex = (flag ? Right : Left);
				}
				else if (num >= 135f)
				{
					abilityIndex = Back;
				}
				if (debug)
				{
					Debug.DrawRay(animal.transform.position, Quaternion.Euler(0f, 45f, 0f) * animal.transform.forward * num2, blue, duration);
					Debug.DrawRay(animal.transform.position, Quaternion.Euler(0f, -45f, 0f) * animal.transform.forward * num2, blue, duration);
					Debug.DrawRay(animal.transform.position, Quaternion.Euler(0f, 135f, 0f) * animal.transform.forward * num2, blue, duration);
					Debug.DrawRay(animal.transform.position, Quaternion.Euler(0f, -135f, 0f) * animal.transform.forward * num2, blue, duration);
					Debug.DrawRay(animal.transform.position, Quaternion.Euler(0f, num * (float)((!flag) ? 1 : (-1)), 0f) * animal.transform.forward * num2, Color.red, duration);
				}
				break;
			case HitDirection.SixSides:
				if (debug)
				{
					Debug.DrawRay(animal.transform.position, animal.transform.forward * num2, blue, duration);
					Debug.DrawRay(animal.transform.position, -animal.transform.forward * num2, blue, duration);
					Debug.DrawRay(animal.transform.position, Quaternion.Euler(0f, 60f, 0f) * animal.transform.forward * num2, blue, duration);
					Debug.DrawRay(animal.transform.position, Quaternion.Euler(0f, -60f, 0f) * animal.transform.forward * num2, blue, duration);
					Debug.DrawRay(animal.transform.position, Quaternion.Euler(0f, 120f, 0f) * animal.transform.forward * num2, blue, duration);
					Debug.DrawRay(animal.transform.position, Quaternion.Euler(0f, -120f, 0f) * animal.transform.forward * num2, blue, duration);
					Debug.DrawRay(animal.transform.position, Quaternion.Euler(0f, num * (float)((!flag) ? 1 : (-1)), 0f) * animal.transform.forward * num2, Color.red, duration);
				}
				if (!flag)
				{
					if (num >= 0f && num <= 60f)
					{
						abilityIndex = FrontRight;
					}
					else if (num > 60f && num <= 120f)
					{
						abilityIndex = Right;
					}
					else if (num > 120f && num <= 180f)
					{
						abilityIndex = BackRight;
					}
				}
				else if (num >= 0f && num <= 60f)
				{
					abilityIndex = FrontLeft;
				}
				else if (num > 60f && num <= 120f)
				{
					abilityIndex = Left;
				}
				else if (num > 120f && num <= 180f)
				{
					abilityIndex = BackLeft;
				}
				break;
			}
			mode.AbilityIndex = abilityIndex;
		}
	}
}
