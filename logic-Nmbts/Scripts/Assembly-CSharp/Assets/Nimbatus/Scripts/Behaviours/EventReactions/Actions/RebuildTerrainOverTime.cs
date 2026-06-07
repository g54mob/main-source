using Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions.Helper;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class RebuildTerrainOverTime : CustomTransformAction
	{
		public float RebuildRadius;

		public override void Execute()
		{
			GameObject gameObject = new GameObject();
			gameObject.transform.position = GetTransform().position;
			gameObject.AddComponent<TerrainRebuilder>().Init(RebuildRadius, 1f);
		}
	}
}
