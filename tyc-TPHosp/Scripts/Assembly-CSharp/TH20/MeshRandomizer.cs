using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class MeshRandomizer : MonoBehaviour
	{
		[SerializeField]
		private Mesh[] _meshes;

		private void Awake()
		{
			MeshFilter component = GetComponent<MeshFilter>();
			if (component != null)
			{
				component.sharedMesh = GetMesh();
			}
		}

		public Mesh GetMesh()
		{
			return _meshes.RandomItem();
		}
	}
}
