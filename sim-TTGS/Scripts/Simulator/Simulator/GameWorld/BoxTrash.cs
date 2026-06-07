using UnityEngine;

namespace Simulator.GameWorld
{
	public class BoxTrash : Trash
	{
		[SerializeField]
		private MeshRenderer m_boxRenderer;

		[SerializeField]
		private Material[] m_boxMaterials;

		private int m_meshIndex;

		protected override void Initialize(DirtData data, int meshIndex = -1)
		{
			base.Initialize(data, meshIndex);
			m_meshIndex = ((meshIndex == -1) ? Random.Range(0, m_boxMaterials.Length) : meshIndex);
			m_boxRenderer.material = m_boxMaterials[m_meshIndex];
		}

		public override void Save()
		{
			SaveManager.CurrentSave.dirt.AddDirtData(new SaveClass_Dirt.SaveDirtData(base.DirtData, base.transform.position, base.transform.eulerAngles, m_meshIndex));
		}
	}
}
