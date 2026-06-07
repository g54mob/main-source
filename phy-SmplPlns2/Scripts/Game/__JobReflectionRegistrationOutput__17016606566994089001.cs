using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Parts.Fuselage;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.CarverParts;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Craft.Wings;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Assets.Scripts.Craft.Wings.Physics;
using Assets.Scripts.Craft.Wings.VFX;
using Assets.Scripts.Design.UI;
using Assets.Scripts.Flight.Combat.Bullets;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__17016606566994089001
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobParallelForExtensions.EarlyJobInit<BulletPoolManager.ProcessBulletHitsJob>();
			IJobParallelForExtensions.EarlyJobInit<BulletPoolManager.UpdateBulletsJob>();
			IJobParallelForExtensions.EarlyJobInit<BulletPoolManager.SetupBulletRenderingJob>();
			IJobExtensions.EarlyJobInit<AirfoilPreviewRenderer.BuildMeshJob>();
			IJobExtensions.EarlyJobInit<GlassGroupScript.CombineJobGlass>();
			IJobExtensions.EarlyJobInit<PartGroupScript.CombineJob>();
			IJobExtensions.EarlyJobInit<ColliderGenerator.AddPointsJob>();
			IJobForExtensions.EarlyJobInit<ColliderGenerator.ConvexBuilder.BakeMeshesJob>();
			IJobExtensions.EarlyJobInit<ColliderGenerator.ConvexBuilder.TransformJob>();
			IJobForExtensions.EarlyJobInit<ColliderGenerator.ConvexBuilder.VerticesToMeshesJob>();
			IJobExtensions.EarlyJobInit<MeshBuilder.CalculateBoundsJob>();
			IJobForExtensions.EarlyJobInit<MeshBuilder.FlipTrianglesJob>();
			IJobForExtensions.EarlyJobInit<MeshBuilder.TransformJob>();
			IJobExtensions.EarlyJobInit<NativeAirfoil.InterpolateJob>();
			IJobExtensions.EarlyJobInit<NativeAirfoil.RenderNativeAirfoilJob>();
			IJobExtensions.EarlyJobInit<RoundedTip.GetMaxInsetJob>();
			IJobExtensions.EarlyJobInit<RoundedTip.GeometryJob>();
			IJobExtensions.EarlyJobInit<SectionJoiner.JoinJob>();
			IJobExtensions.EarlyJobInit<SectionSealer.SectionSealerJob>();
			IJobExtensions.EarlyJobInit<Triangulator.TriangulatorJob>();
			IJobExtensions.EarlyJobInit<WingBuilder.TransferMeshIDsJob>();
			IJobForExtensions.EarlyJobInit<WingBuilder.SetMeshIDsJob>();
			IJobExtensions.EarlyJobInit<WingBuilder.CalculateSliceAreaJob>();
			IJobExtensions.EarlyJobInit<WingTrailRenderer.UpdateMesh>();
			IJobExtensions.EarlyJobInit<AeroForcesManager.CollectDerivativeForcesJob>();
			IJobExtensions.EarlyJobInit<AeroForcesManager.StabiliseForcesJob>();
			IJobExtensions.EarlyJobInit<AeroForcesManager.SimulateForcesJob>();
			IJobExtensions.EarlyJobInit<LiftingLineSolver.LiftingLineSolveJob>();
			IJobExtensions.EarlyJobInit<LiftingLineSolver.PrecalculateJob>();
			IJobExtensions.EarlyJobInit<GeneratePolarsJob>();
			IJobExtensions.EarlyJobInit<EvaluateAndCollectJob>();
			IJobForExtensions.EarlyJobInit<WingPhysicsManager.CopyDebugData>();
			IJobExtensions.EarlyJobInit<BrakeFlap.ColliderJob>();
			IJobExtensions.EarlyJobInit<BrakeFlap.CrossSectionJob>();
			IJobExtensions.EarlyJobInit<FowlerFlap.CrossSectionJob>();
			IJobExtensions.EarlyJobInit<FowlerFlap.ColliderGenJob>();
			IJobExtensions.EarlyJobInit<Slat.ColliderJob>();
			IJobExtensions.EarlyJobInit<Slat.CrossSectionJob>();
			IJobExtensions.EarlyJobInit<SplitFlap.ColliderJob>();
			IJobExtensions.EarlyJobInit<SplitFlap.CrossSectionJob>();
			IJobExtensions.EarlyJobInit<Spoiler.CrossSectionJob>();
			IJobExtensions.EarlyJobInit<Spoiler.PostPassJob>();
			IJobExtensions.EarlyJobInit<StandardFlap.ColliderJob>();
			IJobExtensions.EarlyJobInit<StandardFlap.CrossSectionJob>();
			IJobExtensions.EarlyJobInit<StandardFlap.PostPassJob>();
			IJobForExtensions.EarlyJobInit<FuselageCutter.ConvertSubmeshes>();
			IJobForExtensions.EarlyJobInit<FuselageCutter.ConvertIndexBuffer>();
			IJobExtensions.EarlyJobInit<FuselageCutter.ConvertMeshOutSimple>();
			IJobExtensions.EarlyJobInit<FuselageCutter.ConvertMeshOut>();
			IJobExtensions.EarlyJobInit<FuselageCutter.GetSubmeshIndices>();
			IJobExtensions.EarlyJobInit<FuselageCutter.CutJob>();
			IJobExtensions.EarlyJobInit<JFuselageScript.BakeMeshJob>();
			IJobExtensions.EarlyJobInit<MeshTriangulator.TriangulatorJob>();
			IJobExtensions.EarlyJobInit<ScaleMeshNormalsScript.ScaleNormalsJob>();
			IJobExtensions.EarlyJobInit<MeshModifierBaseScript.CombineCollectedRenderer>();
			IJobExtensions.EarlyJobInit<ProceduralBayScript.GetDoorHingeJob>();
			IJobExtensions.EarlyJobInit<SimpleProcedrualMeshModifierBaseScript.GenerateRoundedManifoldJob>();
			IJobExtensions.EarlyJobInit<TrapezoidMeshModifierScript.MakeTrapezoidManifoldJob>();
			IJobExtensions.EarlyJobInit<FuselageJob>();
			IJobExtensions.EarlyJobInit<FuselageSmoothJob>();
			IJobExtensions.EarlyJobInit<FuselageTestGenerator.MakeFlatShadedMesh>();
			IJobExtensions.EarlyJobInit<ManifoldUtils.ManifoldToMeshJob>();
			IJobExtensions.EarlyJobInit<ManifoldUtils.ManifoldToNativeMeshJob>();
			IJobExtensions.EarlyJobInit<NativeMesh.WriteToSimpleMeshDataJob>();
			IJobExtensions.EarlyJobInit<NativeMesh.WriteToPartMeshDataJob>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex);
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		CreateJobReflectionData();
	}
}
