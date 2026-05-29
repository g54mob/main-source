using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	public class SVGParser
	{
		public struct SceneInfo
		{
			public Scene Scene { get; }

			public Rect SceneViewport { get; }

			public Dictionary<SceneNode, float> NodeOpacity { get; }

			public Dictionary<string, SceneNode> NodeIDs { get; }

			internal SceneInfo(Scene scene, Rect sceneViewport, Dictionary<SceneNode, float> nodeOpacities, Dictionary<string, SceneNode> nodeIDs)
			{
				Scene = null;
				SceneViewport = default(Rect);
				NodeOpacity = null;
				NodeIDs = null;
			}
		}

		public static SceneInfo ImportSVG(TextReader textReader, float dpi = 0f, float pixelsPerUnit = 1f, int windowWidth = 0, int windowHeight = 0, bool clipViewport = false)
		{
			return default(SceneInfo);
		}

		public static SceneInfo ImportSVG(TextReader textReader, ViewportOptions viewportOptions, float dpi = 0f, float pixelsPerUnit = 1f, int windowWidth = 0, int windowHeight = 0)
		{
			return default(SceneInfo);
		}
	}
}
