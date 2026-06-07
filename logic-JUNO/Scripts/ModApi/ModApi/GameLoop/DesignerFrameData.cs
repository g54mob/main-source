using ModApi.Design;
using UnityEngine;

namespace ModApi.GameLoop
{
	public readonly struct DesignerFrameData
	{
		public readonly float DeltaTime;

		public readonly float DeltaTimeUnscaled;

		public readonly IDesigner Designer;

		public readonly int FrameCount;

		public DesignerFrameData(IDesigner designer)
		{
			Designer = designer;
			FrameCount = Time.frameCount;
			DeltaTime = Time.deltaTime;
			DeltaTimeUnscaled = Time.unscaledDeltaTime;
		}
	}
}
