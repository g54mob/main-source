namespace RLD
{
	public class SceneRaycastHit
	{
		private GameObjectRayHit _objectHit;

		private XZGridRayHit _gridHit;

		public bool WasAnythingHit
		{
			get
			{
				if (_objectHit == null)
				{
					return _gridHit != null;
				}
				return true;
			}
		}

		public bool WasAnObjectHit => _objectHit != null;

		public bool WasGridHit => _gridHit != null;

		public GameObjectRayHit ObjectHit => _objectHit;

		public XZGridRayHit GridHit => _gridHit;

		public SceneRaycastHit(GameObjectRayHit objectRayHit, XZGridRayHit gridRayHit)
		{
			_objectHit = objectRayHit;
			_gridHit = gridRayHit;
		}
	}
}
