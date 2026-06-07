using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Shapes
{
	internal abstract class MetaMpb : IDisposable
	{
		private bool initialized;

		private int instanceCount;

		private ShapeDrawState drawState;

		public MaterialPropertyBlock mpbOverride;

		private Matrix4x4[] matrices = ArrayPool<Matrix4x4>.Alloc(1023);

		private bool directMaterialApply;

		internal List<Vector4> color = InitList<Vector4>();

		private ShapeDrawCall sdc;

		public bool HasContent => initialized;

		private bool HasMultipleInstances => instanceCount > 1;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void ApplyColorOrFill<T>(T fillable, Color baseColor) where T : MetaMpb, IFillableMpb
		{
			if (Draw.style.useGradients)
			{
				GradientFill gradientFill = Draw.style.gradientFill;
				fillable.color.Add(gradientFill.colorStart.ColorSpaceAdjusted());
				fillable.fillType.Add((float)gradientFill.type);
				fillable.fillSpace.Add((float)gradientFill.space);
				fillable.fillStart.Add(gradientFill.GetShaderStartVector());
				fillable.fillColorEnd.Add(gradientFill.colorEnd.ColorSpaceAdjusted());
				fillable.fillEnd.Add(gradientFill.linearEnd);
			}
			else
			{
				fillable.color.Add(baseColor.ColorSpaceAdjusted());
				fillable.fillType.Add(-1f);
				fillable.fillSpace.Add(0f);
				fillable.fillStart.Add(default(Vector4));
				fillable.fillColorEnd.Add(default(Vector4));
				fillable.fillEnd.Add(default(Vector4));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void ApplyDashSettings<T>(T dashable, float thickness) where T : MetaMpb, IDashableMpb
		{
			if (Draw.UseDashes && Draw.DashStyle.size > 0f)
			{
				DashStyle dashStyle = Draw.DashStyle;
				dashable.dashSize.Add(dashStyle.GetNetAbsoluteSize(dashed: true, thickness));
				dashable.dashType.Add((float)dashStyle.type);
				dashable.dashShapeModifier.Add(dashStyle.shapeModifier);
				dashable.dashSpace.Add((float)dashStyle.space);
				dashable.dashSnap.Add((float)dashStyle.snap);
				dashable.dashOffset.Add(dashStyle.offset);
				dashable.dashSpacing.Add(dashStyle.GetNetAbsoluteSpacing(dashed: true, thickness));
			}
			else
			{
				dashable.dashSize.Add(0f);
				dashable.dashType.Add(0f);
				dashable.dashShapeModifier.Add(0f);
				dashable.dashSpace.Add(0f);
				dashable.dashSnap.Add(0f);
				dashable.dashOffset.Add(0f);
				dashable.dashSpacing.Add(0f);
			}
		}

		internal static List<T> InitList<T>()
		{
			return new List<T>(1023);
		}

		protected abstract void TransferShapeProperties();

		protected void Transfer(int propertyID, List<Vector4> listVec)
		{
			if (directMaterialApply)
			{
				drawState.mat.SetVector(propertyID, listVec[0]);
			}
			else if (HasMultipleInstances)
			{
				sdc.mpb.SetVectorArray(propertyID, listVec);
			}
			else
			{
				sdc.mpb.SetVector(propertyID, listVec[0]);
			}
			listVec.Clear();
		}

		protected void Transfer(int propertyID, List<float> listFloat)
		{
			if (directMaterialApply)
			{
				drawState.mat.SetFloat(propertyID, listFloat[0]);
			}
			else if (HasMultipleInstances)
			{
				sdc.mpb.SetFloatArray(propertyID, listFloat);
			}
			else
			{
				sdc.mpb.SetFloat(propertyID, listFloat[0]);
			}
			listFloat.Clear();
		}

		protected void Transfer(int propertyID, ref Texture tex)
		{
			if (directMaterialApply)
			{
				drawState.mat.SetTexture(propertyID, tex);
			}
			else
			{
				sdc.mpb.SetTexture(propertyID, tex);
			}
			tex = null;
		}

		public bool PreAppendCheck(ShapeDrawState additionDrawState, Matrix4x4 mtx)
		{
			bool flag = false;
			if (!initialized)
			{
				initialized = true;
				drawState = additionDrawState;
				flag = true;
			}
			else if (instanceCount < 1023 && drawState.CompatibleWith(additionDrawState))
			{
				flag = true;
			}
			if (flag)
			{
				matrices[instanceCount++] = mtx;
			}
			return flag;
		}

		public ShapeDrawCall ExtractDrawCall()
		{
			if (HasMultipleInstances)
			{
				sdc = new ShapeDrawCall(drawState, instanceCount, matrices);
				matrices = ArrayPool<Matrix4x4>.Alloc(1023);
			}
			else
			{
				sdc = new ShapeDrawCall(drawState, matrices[0]);
			}
			TransferAllProperties();
			Dispose();
			return sdc;
		}

		public void ApplyDirectlyToMaterial()
		{
			directMaterialApply = true;
			TransferAllProperties();
			directMaterialApply = false;
			Dispose();
		}

		internal void TransferAllProperties()
		{
			if (this is MpbCustomMesh)
			{
				if (mpbOverride != null)
				{
					sdc.mpb = mpbOverride;
				}
				return;
			}
			if (!(this is MpbText))
			{
				Transfer(ShapesMaterialUtils.propColor, color);
			}
			if (this is IFillableMpb fillableMpb)
			{
				Transfer(ShapesMaterialUtils.propFillType, fillableMpb.fillType);
				Transfer(ShapesMaterialUtils.propFillSpace, fillableMpb.fillSpace);
				Transfer(ShapesMaterialUtils.propFillStart, fillableMpb.fillStart);
				Transfer(ShapesMaterialUtils.propColorEnd, fillableMpb.fillColorEnd);
				Transfer(ShapesMaterialUtils.propFillEnd, fillableMpb.fillEnd);
			}
			if (this is IDashableMpb dashableMpb)
			{
				Transfer(ShapesMaterialUtils.propDashSize, dashableMpb.dashSize);
				Transfer(ShapesMaterialUtils.propDashType, dashableMpb.dashType);
				Transfer(ShapesMaterialUtils.propDashShapeModifier, dashableMpb.dashShapeModifier);
				Transfer(ShapesMaterialUtils.propDashSpace, dashableMpb.dashSpace);
				Transfer(ShapesMaterialUtils.propDashSnap, dashableMpb.dashSnap);
				Transfer(ShapesMaterialUtils.propDashOffset, dashableMpb.dashOffset);
				Transfer(ShapesMaterialUtils.propDashSpacing, dashableMpb.dashSpacing);
			}
			TransferShapeProperties();
		}

		public void Dispose()
		{
			initialized = false;
			drawState = default(ShapeDrawState);
			instanceCount = 0;
		}
	}
}
