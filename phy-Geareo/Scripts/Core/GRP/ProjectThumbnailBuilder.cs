using System.Collections.Generic;
using System.Threading.Tasks;
using Rhizomatic;
using UnityEngine;

namespace GRP
{
	public class ProjectThumbnailBuilder : MonoBehaviour
	{
		public GameObject scene;

		public Camera cam;

		public ProjectView projectView;

		public ProjectConfigEntry projectConfig;

		public Project project;

		public ProjectViewable projectViewable;

		public List<TaskCompletionSource<bool>> queue;

		private Context context;

		private RenderTexture renderTexture;

		private bool isSession;

		public static ProjectThumbnailBuilder instance;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void SetResolution(int width, int height)
		{
		}

		public void NewProject()
		{
		}

		public void Finish()
		{
		}

		public void UpdateView()
		{
		}

		public PartView GetPartView(Id id)
		{
			return null;
		}

		public Task StartSession()
		{
			return null;
		}

		public void EndSession()
		{
		}

		public Task<Texture2D> Snapshot(List<Id> targets, float size, Quaternion rotation)
		{
			return null;
		}
	}
}
