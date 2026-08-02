using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/ExhibitBuilderConfig", fileName = "ExhibitBuilderConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class ExhibitBuilderConfig : ScriptableObject
	{
		public Mesh box;

		public Mesh cylinder;

		public Mesh sphere;

		public Mesh prism;

		public float colorStep;
	}
}
