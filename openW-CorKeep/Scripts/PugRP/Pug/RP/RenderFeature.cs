using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.RP
{
	public abstract class RenderFeature
	{
		private CullingResults m_cullingResults;

		private bool m_hasCullingResults;

		public abstract bool usesCulling { get; }

		public bool hasCullingResults
		{
			get
			{
				if (!PugRP.useSharedCullPass)
				{
					return m_hasCullingResults;
				}
				return true;
			}
		}

		public bool isValid { get; protected set; }

		public abstract string sampleName { get; }

		public virtual string sampleNameEarly => "";

		public virtual string sampleNameLate => "";

		public virtual string featureKeyword => "";

		public virtual string featurePassKeyword => "";

		public virtual RenderPipelineStage executionStage => RenderPipelineStage.None;

		public virtual RenderPipelineStage executionStageEarly => RenderPipelineStage.None;

		public virtual RenderPipelineStage executionStageLate => RenderPipelineStage.None;

		public abstract void ValidateFrame(PugRPContext context);

		public abstract void OnBeginValidFrame(PugRPContext context);

		public virtual void Cull(PugRPContext context)
		{
		}

		public virtual void Execute(PugRPContext context, CommandBuffer cmd)
		{
		}

		public virtual void ExecuteEarly(PugRPContext context, CommandBuffer cmd)
		{
		}

		public virtual void ExecuteLate(PugRPContext context, CommandBuffer cmd)
		{
		}

		public abstract void ExecuteDisabled(PugRPContext context, CommandBuffer cmd);

		public void Dispose()
		{
			m_hasCullingResults = false;
			DisposeInternal();
		}

		protected abstract void DisposeInternal();

		public RenderPipelineStage GetExecutionStageForPass(RenderPipelineStagePass pass)
		{
			return pass switch
			{
				RenderPipelineStagePass.Early => executionStageEarly, 
				RenderPipelineStagePass.Late => executionStageLate, 
				_ => executionStage, 
			};
		}

		public virtual void AppendSharedCullData(ref Bounds bounds, ref int cullingMask, ref CullingOptions cullingOptions)
		{
		}

		protected void Cull(PugRPContext context, Camera camera, CullingOptions cullingOptions = CullingOptions.ForceEvenIfCameraIsNotActive | CullingOptions.NeedsLighting | CullingOptions.DisablePerObjectCulling)
		{
			if (PugRP.useSharedCullPass)
			{
				PugRP.AppendSharedCullData(PugRPUtils.GetCameraFrustumBounds(camera), camera.cullingMask, cullingOptions);
			}
			else
			{
				m_hasCullingResults = context.Cull(camera, ref m_cullingResults, cullingOptions);
			}
		}

		public bool GetCullingResults(out CullingResults cullingResults)
		{
			cullingResults = (PugRP.useSharedCullPass ? PugRP.sharedCullingResults : m_cullingResults);
			return hasCullingResults;
		}

		public virtual void AddVisibleLights(HashSet<Light> lights)
		{
			if (PugRP.useSharedCullPass || !usesCulling || !m_hasCullingResults || !m_cullingResults.visibleLights.IsCreated)
			{
				return;
			}
			foreach (VisibleLight visibleLight in m_cullingResults.visibleLights)
			{
				lights.Add(visibleLight.light);
			}
		}
	}
}
