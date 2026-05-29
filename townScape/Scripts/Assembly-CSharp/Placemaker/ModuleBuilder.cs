using System.Collections.Generic;
using Placemaker.Graphs;
using UnityEngine;

namespace Placemaker
{
	public class ModuleBuilder : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		public Transform moduleContainerPool;

		[SerializeField]
		public Transform moduleContainersToDeconstruct;

		public List<Qube> qubesToGrass;

		public static Vector4 GetTs(Vector3 srcVert)
		{
			return default(Vector4);
		}

		public static Vector3 MultiplyVector(Square square, Vector4 ts, Vector3 vector)
		{
			return default(Vector3);
		}

		public static Vector3 MultiplyPoint(Square square, Vector4 ts, Vector3 vector)
		{
			return default(Vector3);
		}

		private ModuleContainer GetModuleContainer()
		{
			return null;
		}

		public void ApplyModule(Qube qube, OrientedModuleSides possibleModule)
		{
		}

		public void ApplyDecor(Qube qube)
		{
		}

		public bool Iterate()
		{
			return false;
		}

		public void MaybeAddToGrassQueue(Qube qube)
		{
		}

		public void OnStart()
		{
		}

		public void MarkQubeForDeconstruction(Qube qube)
		{
		}

		public void MarkModuleContainerForDeconstruction(ModuleContainer container)
		{
		}

		public void DeconstructModuleContainer(ModuleContainer container)
		{
		}

		public bool IterateDeconstructQubes()
		{
			return false;
		}
	}
}
