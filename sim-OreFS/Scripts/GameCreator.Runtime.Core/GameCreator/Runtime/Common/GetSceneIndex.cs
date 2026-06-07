using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Scene Index")]
	[Category("Scene Index")]
	[Image(typeof(IconNumber), ColorTheme.Type.Blue)]
	[Description("The Scene reference by its index in the Build Settings")]
	public class GetSceneIndex : PropertyTypeGetScene
	{
		[SerializeField]
		protected PropertyGetInteger m_Index = GetDecimalInteger.Create(0);

		public static PropertyGetScene Create => new PropertyGetScene(new GetSceneIndex());

		public override string String => m_Index.ToString();

		public override int Get(Args args)
		{
			return (int)m_Index.Get(args);
		}
	}
}
