using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Handle")]
	[Category("Handle")]
	[Image(typeof(IconHandle), ColorTheme.Type.Yellow)]
	public class HandleItem : TPolymorphicItem<HandleItem>
	{
		[SerializeField]
		private RunConditionsList m_Conditions = new RunConditionsList();

		[SerializeField]
		private Bone m_Bone = new Bone(HumanBodyBones.RightHand);

		[SerializeField]
		private PropertyGetPosition m_LocalPosition = GetPositionVector3.Create();

		[SerializeField]
		private PropertyGetRotation m_LocalRotation = GetRotationConstantEulerVector.Create();

		public Bone Bone => m_Bone;

		public override string Title
		{
			get
			{
				string text = m_Conditions.ToString();
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
				return "Default";
			}
		}

		public bool CheckConditions(Args args)
		{
			return m_Conditions.Check(args);
		}

		public Vector3 GetPosition(Args args)
		{
			return m_LocalPosition.Get(args);
		}

		public Quaternion GetRotation(Args args)
		{
			return m_LocalRotation.Get(args);
		}
	}
}
