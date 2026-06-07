using System.Collections.Generic;

namespace Assets.Scripts.Terrain.Pooling
{
	public class QuadScriptPool : QuadSpherePool<QuadScript>
	{
		private List<QuadScript> _quadScripts;

		public QuadScriptPool(int initialSize)
			: base(initialSize)
		{
			_quadScripts = new List<QuadScript>(initialSize + 1);
			GrowQuadScriptsList(initialSize + 1);
		}

		public QuadScript GetById(int id)
		{
			if (_quadScripts.Count > id)
			{
				return _quadScripts[id];
			}
			return null;
		}

		protected override QuadScript CreateItem(int id)
		{
			if (_quadScripts.Count <= id)
			{
				GrowQuadScriptsList(id + 100);
			}
			QuadScript quadScript = new QuadScript(id);
			_quadScripts[id] = quadScript;
			return quadScript;
		}

		protected override void Destroy(QuadScript item)
		{
			_quadScripts[item.Id] = null;
		}

		private void GrowQuadScriptsList(int size)
		{
			for (int i = _quadScripts.Count; i < size; i++)
			{
				_quadScripts.Add(null);
			}
		}
	}
}
