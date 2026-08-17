using System;
using Assets.Scripts.Actors.Player;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeModifiers;

public class ChallengeModifierBlind : ChallengeModifier
{
	public override void Init(ChallengeData challengeData)
	{
		//IL_0124: Expected I, but got O
		Action b = OnGenerationComplete;
		Delegate obj = Delegate.Combine(MapGenerationController.A_GenerationComplete, b);
		if ((object)obj == null)
		{
			MapGenerationController.A_GenerationComplete = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			MapGenerationController.A_GenerationComplete = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_0124: Expected I, but got O
		Action value = OnGenerationComplete;
		Delegate obj = Delegate.Remove(MapGenerationController.A_GenerationComplete, value);
		if ((object)obj == null)
		{
			MapGenerationController.A_GenerationComplete = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			MapGenerationController.A_GenerationComplete = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private unsafe void OnGenerationComplete()
	{
		//IL_0046: Expected O, but got Ref
		//IL_0046: Expected O, but got Ref
		//IL_006b: Expected O, but got Ref
		EffectManager instance = EffectManager.Instance;
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		float num = default(float);
		object obj = default(object);
		GameObject gameObject = UnityEngine.Object.Instantiate(instance.blindSphere, (Vector3)(&num), (Quaternion)(&obj));
		RenderSettings.fogDensity = 0.035f;
		Color fogColor = RenderSettings.fogColor;
		RenderSettings.fogColor = (Color)(&num);
	}
}
