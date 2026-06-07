using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Last Pick from Pool")]
	[Category("Game Objects/Last Pick from Pool")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue, typeof(OverlayArrowRight))]
	[Description("The last Game Object instance picked from its Pool")]
	[HideLabelsInEditor(true)]
	public class GetGameObjectLastPoolPick : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected PropertyGetGameObject m_Prefab = GetGameObjectInstance.Create();

		public override string String => $"Pool[{m_Prefab}] Last Pick";

		public override GameObject Get(Args args)
		{
			GameObject prefab = m_Prefab.Get(args);
			return Singleton<PoolManager>.Instance.GetLastPicked(prefab);
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectLastPoolPick());
		}
	}
}
