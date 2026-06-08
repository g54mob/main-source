using System;
using Jobberwocky.GeometryAlgorithms.Source.Algorithms.Triangulation2D;
using Jobberwocky.GeometryAlgorithms.Source.Algorithms.Triangulation3D;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.API
{
	public class TriangulationAPI : ThreadingAPI
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<IParameters, Action<Geometry>, ThreadingResult> _003C_003E9__2_0;

			internal ThreadingResult _003CTriangulate2DAsync_003Eb__2_0(IParameters param, Action<Geometry> callbackResult)
			{
				Geometry output = new Triangulation2DWrapper().Triangulate2D((Triangulation2DParameters)param);
				return new ThreadingResult(callbackResult, output);
			}
		}

		public Geometry Triangulate2DRaw(Triangulation2DParameters parameters)
		{
			return new Triangulation2DWrapper().Triangulate2D(parameters);
		}

		public Mesh Triangulate2D(Triangulation2DParameters parameters)
		{
			return Triangulate2DRaw(parameters).ToUnityMesh();
		}

		public void Triangulate2DAsync(Action<Geometry> callback, Triangulation2DParameters parameters = null)
		{
			ThreadingAPI.StartWorker(delegate(IParameters param, Action<Geometry> callbackResult)
			{
				Geometry output = new Triangulation2DWrapper().Triangulate2D((Triangulation2DParameters)param);
				return new ThreadingResult(callbackResult, output);
			}, parameters, callback);
		}

		public Mesh Triangulate3D(Triangulation3DParameters parameters)
		{
			return Triangulate3DRaw(parameters).ToUnityMesh();
		}

		public Geometry Triangulate3DRaw(Triangulation3DParameters parameters)
		{
			return new Triangulation3DWrapper().Triangulate3D(parameters);
		}
	}
}
