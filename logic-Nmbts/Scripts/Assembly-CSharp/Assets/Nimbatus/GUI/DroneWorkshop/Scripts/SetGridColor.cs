using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class SetGridColor : MonoBehaviour
	{
		public MeshRenderer Renderer;

		public void Start()
		{
			Renderer.material.color = RuntimeGlobals.Settings.GridColor;
		}
	}
}
