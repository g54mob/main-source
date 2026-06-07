using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERDecalClass
	{
		public int id = 0;

		public ERDecalType type = ERDecalType.StartEnd;

		public string name = "";

		public double roadType1 = 0.0;

		public double roadType2 = 0.0;

		public int connection = 0;

		public GameObject decalPrefab;

		public float baseWidth = 6f;

		public float meshWidth = 0f;

		public float scale = 1f;

		public Vector3 localScale = new Vector3(1f, 1f, 1f);

		public int priority = 0;

		public bool collapsed = false;

		public float heightOffset = 0f;

		public Material material;

		public Vector2 uvLeftTop = new Vector2(0.45f, 0.75f);

		public Vector2 uvRightBottom = new Vector2(0.55f, 0.25f);

		public float width = 0f;

		public float length = 5f;

		public float xOffset = 0f;

		public float startOffset = 0f;

		public float endOffset = 0f;

		public List<Vector2> uvBreakPoints = new List<Vector2>();

		public List<float> distances = new List<float>();

		public ERLaneDirectionOptions laneDirecionType = ERLaneDirectionOptions.Straight;

		public float distance = 50f;

		public float distanceToIntersection = 30f;

		public float distanceAtIntersection = 15f;

		public Vector2 uvLeftTop1 = new Vector2(0.45f, 0.75f);

		public Vector2 uvRightBottom1 = new Vector2(0.55f, 0.25f);

		public Vector2 uvLeftTop2 = new Vector2(0.45f, 0.75f);

		public Vector2 uvRightBottom2 = new Vector2(0.55f, 0.25f);

		public float width1 = 0f;

		public float width2 = 0f;

		public List<Vector2> shape = new List<Vector2>();

		public List<float> shapeUVs = new List<float>();

		public bool startEndSections = false;

		public bool interpolatedStartEndSections = false;

		public bool projector = false;

		public int renderingLayerMask = 0;

		public float drawDistance = 500f;

		public float fadeDistance = 0.9f;

		public bool affectsTransparency = true;

		public float overlap = 0.5f;

		public static void CopyDecal(ERDecal source, ERDecalClass target)
		{
			if (!(source == null))
			{
				target.id = source.id;
				target.name = source.name;
				target.type = source.type;
				target.roadType1 = source.roadType1;
				target.roadType2 = source.roadType2;
				target.connection = source.connection;
				target.decalPrefab = source.decalPrefab;
				target.baseWidth = source.baseWidth;
				target.meshWidth = source.meshWidth;
				target.scale = source.scale;
				target.localScale = source.localScale;
				target.priority = source.priority;
				target.collapsed = source.collapsed;
				target.heightOffset = source.heightOffset;
				target.material = source.material;
				target.uvLeftTop = source.uvLeftTop;
				target.uvRightBottom = source.uvRightBottom;
				target.width = source.width;
				target.length = source.length;
				target.xOffset = source.xOffset;
				target.startOffset = source.startOffset;
				target.endOffset = source.endOffset;
				if (source.uvBreakPoints != null)
				{
					target.uvBreakPoints = new List<Vector2>(source.uvBreakPoints);
				}
				if (source.distances != null)
				{
					target.distances = new List<float>(source.distances);
				}
				target.uvLeftTop1 = source.uvLeftTop1;
				target.uvRightBottom1 = source.uvRightBottom1;
				target.uvLeftTop2 = source.uvLeftTop2;
				target.uvRightBottom2 = source.uvRightBottom2;
				target.width1 = source.width1;
				target.width2 = source.width2;
				target.laneDirecionType = source.laneDirecionType;
				target.distance = source.distance;
				target.distanceToIntersection = source.distanceToIntersection;
				target.distanceAtIntersection = source.distanceAtIntersection;
				target.shape = new List<Vector2>(source.shape);
				target.shapeUVs = new List<float>(source.shapeUVs);
				target.startEndSections = source.startEndSections;
				target.interpolatedStartEndSections = source.interpolatedStartEndSections;
				target.projector = source.projector;
				target.renderingLayerMask = source.renderingLayerMask;
				target.drawDistance = source.drawDistance;
				target.fadeDistance = source.fadeDistance;
				target.affectsTransparency = source.affectsTransparency;
				target.overlap = source.overlap;
			}
		}
	}
}
