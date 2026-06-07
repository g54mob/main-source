using System;
using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class StopModelerBuild : IDisposable
	{
		private struct BuildShelfArg
		{
			public int shelf;

			public bool updateToGraphicsAPIImmediately;
		}

		private static StopModelerBuild stopModelerBuild_;

		private List<BuildShelfArg> buildSelfs_ = new List<BuildShelfArg>();

		private List<int> BuildEdMeshSelfs_ = new List<int>();

		private UModeler modeler_;

		public static bool CheckBuild(int shelf, bool updateToGraphicsAPIImmediately)
		{
			if (stopModelerBuild_ == null)
			{
				return true;
			}
			BuildShelfArg item = new BuildShelfArg
			{
				shelf = shelf,
				updateToGraphicsAPIImmediately = updateToGraphicsAPIImmediately
			};
			if (!stopModelerBuild_.buildSelfs_.Contains(item))
			{
				stopModelerBuild_.buildSelfs_.Add(item);
			}
			return false;
		}

		public static bool CheckBuildEdMesh(int shelf)
		{
			if (stopModelerBuild_ == null)
			{
				return true;
			}
			if (!stopModelerBuild_.BuildEdMeshSelfs_.Contains(shelf))
			{
				stopModelerBuild_.BuildEdMeshSelfs_.Add(shelf);
			}
			return false;
		}

		public StopModelerBuild(UModeler modeler)
		{
			if (stopModelerBuild_ == null)
			{
				stopModelerBuild_ = this;
				modeler_ = modeler;
			}
			else
			{
				Debug.Log("Already build");
			}
		}

		public void Dispose()
		{
			if (stopModelerBuild_ != null)
			{
				stopModelerBuild_ = null;
				RunBuild();
			}
			else
			{
				Debug.Log("Already build Dispose");
			}
		}

		private void RunBuild()
		{
			foreach (BuildShelfArg item in buildSelfs_)
			{
				modeler_.Build(item.shelf, item.updateToGraphicsAPIImmediately);
			}
			foreach (int item2 in BuildEdMeshSelfs_)
			{
				modeler_.BuildEdMesh(item2);
			}
		}
	}
}
