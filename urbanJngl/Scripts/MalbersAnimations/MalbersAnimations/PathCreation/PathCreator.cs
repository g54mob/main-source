using System;
using UnityEngine;

namespace MalbersAnimations.PathCreation
{
	[AddComponentMenu("Malbers/Animal Controller/Path Creator (SL)")]
	[HelpURL("https://youtu.be/saAQNRSYU9k")]
	public class PathCreator : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
		private PathCreatorData editorData;

		[SerializeField]
		[HideInInspector]
		private bool initialized;

		private GlobalDisplaySettings globalEditorDisplaySettings;

		public VertexPath path
		{
			get
			{
				if (!initialized)
				{
					InitializeEditorData(in2DMode: false);
				}
				return editorData.GetVertexPath(base.transform);
			}
		}

		public BezierPath bezierPath
		{
			get
			{
				if (!initialized)
				{
					InitializeEditorData(in2DMode: false);
				}
				return editorData.bezierPath;
			}
			set
			{
				if (!initialized)
				{
					InitializeEditorData(in2DMode: false);
				}
				editorData.bezierPath = value;
			}
		}

		public PathCreatorData EditorData => editorData;

		public event Action pathUpdated;

		public void InitializeEditorData(bool in2DMode)
		{
			if (editorData == null)
			{
				editorData = new PathCreatorData();
			}
			editorData.bezierOrVertexPathModified -= TriggerPathUpdate;
			editorData.bezierOrVertexPathModified += TriggerPathUpdate;
			editorData.Initialize(in2DMode);
			initialized = true;
		}

		public void TriggerPathUpdate()
		{
			if (this.pathUpdated != null)
			{
				this.pathUpdated();
			}
		}
	}
}
