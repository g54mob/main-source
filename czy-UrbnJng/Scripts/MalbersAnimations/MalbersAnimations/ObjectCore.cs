using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Animal Controller/Object Core")]
	public class ObjectCore : MonoBehaviour, IObjectCore
	{
		Transform IObjectCore.transform => base.transform;
	}
}
