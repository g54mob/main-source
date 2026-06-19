namespace Pug.UnityExtensions
{
	internal class NativeUnionFindDebugView
	{
		private NativeUnionFind _uf;

		public int[] Items => _uf.ToArray();

		public NativeUnionFindDebugView(NativeUnionFind uf)
		{
			_uf = uf;
		}
	}
}
