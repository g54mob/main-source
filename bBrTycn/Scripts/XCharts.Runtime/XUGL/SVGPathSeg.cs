using System.Collections.Generic;
using UnityEngine;

namespace XUGL
{
	public class SVGPathSeg
	{
		public SVGPathSegType type;

		public bool relative;

		public List<float> parameters = new List<float>();

		public string raw;

		public float value
		{
			get
			{
				if (type == SVGPathSegType.H)
				{
					if (!SVG.yMirror)
					{
						return parameters[0];
					}
					return 0f - parameters[0];
				}
				return parameters[0];
			}
		}

		public float x => parameters[0];

		public float y
		{
			get
			{
				if (!SVG.yMirror)
				{
					return parameters[1];
				}
				return 0f - parameters[1];
			}
		}

		public Vector2 p1 => new Vector2(parameters[0], SVG.yMirror ? (0f - parameters[1]) : parameters[1]);

		public Vector2 p2 => new Vector2(parameters[2], SVG.yMirror ? (0f - parameters[3]) : parameters[3]);

		public Vector2 p3 => new Vector2(parameters[4], SVG.yMirror ? (0f - parameters[5]) : parameters[5]);

		public SVGPathSeg(SVGPathSegType type)
		{
			this.type = type;
		}
	}
}
