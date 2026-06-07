using UnityEngine;

namespace TerrainComposer2
{
	public class RuntimeGenerate : MonoBehaviour
	{
		public bool generateOnStart = true;

		public bool generateOnUpdate;

		public bool generateHeight = true;

		public bool generateSplat = true;

		public bool generateColor = true;

		public bool generateGrass = true;

		public bool generateTrees = true;

		public bool generateObjects = true;

		private void Start()
		{
			if (generateOnStart)
			{
				Generate();
			}
		}

		private void Update()
		{
			if (generateOnUpdate)
			{
				Generate();
			}
		}

		public void Generate()
		{
			if (generateHeight)
			{
				TC_Generate.instance.Generate(instantGenerate: true, 0);
			}
			if (generateSplat)
			{
				TC_Generate.instance.Generate(instantGenerate: true, 1);
			}
			if (generateColor)
			{
				TC_Generate.instance.Generate(instantGenerate: true, 2);
			}
			if (generateGrass)
			{
				TC_Generate.instance.Generate(instantGenerate: true, 4);
			}
			if (generateTrees)
			{
				TC_Generate.instance.Generate(instantGenerate: true, 3);
			}
			if (generateObjects)
			{
				TC_Generate.instance.Generate(instantGenerate: true, 5);
			}
		}
	}
}
