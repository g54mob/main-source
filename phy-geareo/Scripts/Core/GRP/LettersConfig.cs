using System.Collections.Generic;
using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/LettersConfig", fileName = "LettersConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class LettersConfig : ScriptableObject
	{
		public float size;

		public float ratio;

		public Vector3 rotation;

		public List<Mesh> letters;

		public Dictionary<char, Mesh> lettersDic;

		public void Build()
		{
		}

		public Mesh LetterToMesh(char letter)
		{
			return null;
		}
	}
}
