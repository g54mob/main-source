using Unity.Mathematics;

public class PhaserScene
{
	public class Renderer
	{
		public float width;

		public float height;

		public int pixelWidth;

		public int pixelHeight;

		public float screenWidth;

		public float screenHeight;

		public float screenWidthPixels;

		public float screenHeightPixels;

		public float sortPivotY;

		public float2 screenCenter;

		public float2 cameraVelocity;

		public ArcadeRect playArea;

		private float2 lastScreenCenter;

		private bool firstFrame;

		public void UpdateCameraVelocity()
		{
		}

		public bool IsInPlayableScreenBounds(float2 point)
		{
			return false;
		}
	}

	public class BoxedVector2
	{
		public float x;

		public float y;

		public BoxedVector2(float x, float y)
		{
		}
	}

	public class CameraSet
	{
		public PhaserCamera main;
	}

	public Factory add;

	public ArcadePhysics physics;

	public CameraSet cameras;

	private Renderer _renderer;

	public Renderer renderer => null;

	public void UpdateRendererCache()
	{
	}
}
