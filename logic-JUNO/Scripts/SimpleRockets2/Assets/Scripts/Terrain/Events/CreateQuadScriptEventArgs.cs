using System;

namespace Assets.Scripts.Terrain.Events
{
	public class CreateQuadScriptEventArgs : EventArgs
	{
		private int _childIndex;

		private CreateQuadData _createQuadData;

		private QuadScript _parentQuad;

		private QuadScript _quad;

		private QuadSphereScript _quadSphere;

		public int ChildIndex => _childIndex;

		public CreateQuadData CreateQuadData => _createQuadData;

		public QuadScript ParentQuad => _parentQuad;

		public QuadScript Quad => _quad;

		public QuadSphereScript QuadSphere => _quadSphere;

		public void Initialize(QuadSphereScript quadSphere, QuadScript parentQuad, QuadScript quad, CreateQuadData createQuadData, int childIndex)
		{
			_quadSphere = quadSphere;
			_parentQuad = parentQuad;
			_quad = quad;
			_createQuadData = createQuadData;
			_childIndex = childIndex;
		}

		public void Reset()
		{
			_quadSphere = null;
			_parentQuad = null;
			_quad = null;
			_createQuadData = null;
			_childIndex = -1;
		}
	}
}
