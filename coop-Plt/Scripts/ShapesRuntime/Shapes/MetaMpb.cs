using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal abstract class MetaMpb : IDisposable
	{
		private bool initialized;

		private int instanceCount;

		private ShapeDrawState drawState;

		private List<Matrix4x4> matrices = InitList<Matrix4x4>();

		private bool directMaterialApply;

		internal List<Vector4> color = InitList<Vector4>();

		private ShapeDrawCall sdc;

		public bool HasContent => initialized;

		private bool HasMultipleInstances => instanceCount > 1;

		internal static void ApplyColorOrFill<T>(T fillable, ShapeFill fill, Color baseColor) where T : MetaMpb, IFillable
		{
			bool flag = fill != null;
			fillable.color.Add(flag ? fill.colorStart : baseColor);
			fillable.fillType.Add(fill.GetShaderFillModeInt());
			fillable.fillSpace.Add(flag ? ((float)fill.space) : 0f);
			fillable.fillStart.Add(flag ? fill.GetShaderStartVector() : default(Vector4));
			fillable.fillColorEnd.Add(flag ? fill.colorEnd : default(Color));
			fillable.fillEnd.Add(flag ? fill.linearEnd : default(Vector3));
		}

		internal static void ApplyDashSettings<T>(T dashable, DashStyle style, float thickness) where T : MetaMpb, IDashable
		{
			bool flag = style != null && style.size > 0f;
			dashable.dashSize.Add(flag ? style.GetNetAbsoluteSize(dashed: true, thickness) : 0f);
			dashable.dashType.Add(flag ? ((float)style.type) : 0f);
			dashable.dashShapeModifier.Add(flag ? style.shapeModifier : 0f);
			dashable.dashSpace.Add(flag ? ((float)style.space) : 0f);
			dashable.dashSnap.Add((float)(flag ? style.snap : DashSnapping.Off));
			dashable.dashOffset.Add(flag ? style.offset : 0f);
			dashable.dashSpacing.Add(flag ? style.GetNetAbsoluteSpacing(dashed: true, thickness) : 0f);
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
				instanceCount++;
				matrices.Add(mtx);
			}
			return flag;
		}

		public ShapeDrawCall ExtractDrawCall()
		{
			if (HasMultipleInstances)
			{
				sdc = new ShapeDrawCallInstanced(matrices.ToArray());
			}
			else
			{
				sdc = new ShapeDrawCallSingle(matrices[0]);
			}
			sdc.count = instanceCount;
			sdc.drawState = drawState;
			sdc.mpb = new MaterialPropertyBlock();
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
			if (!(this is MpbText))
			{
				Transfer(ShapesMaterialUtils.propColor, color);
			}
			if (this is IFillable fillable)
			{
				Transfer(ShapesMaterialUtils.propFillType, fillable.fillType);
				Transfer(ShapesMaterialUtils.propFillSpace, fillable.fillSpace);
				Transfer(ShapesMaterialUtils.propFillStart, fillable.fillStart);
				Transfer(ShapesMaterialUtils.propColorEnd, fillable.fillColorEnd);
				Transfer(ShapesMaterialUtils.propFillEnd, fillable.fillEnd);
			}
			if (this is IDashable dashable)
			{
				Transfer(ShapesMaterialUtils.propDashSize, dashable.dashSize);
				Transfer(ShapesMaterialUtils.propDashType, dashable.dashType);
				Transfer(ShapesMaterialUtils.propDashShapeModifier, dashable.dashShapeModifier);
				Transfer(ShapesMaterialUtils.propDashSpace, dashable.dashSpace);
				Transfer(ShapesMaterialUtils.propDashSnap, dashable.dashSnap);
				Transfer(ShapesMaterialUtils.propDashOffset, dashable.dashOffset);
				Transfer(ShapesMaterialUtils.propDashSpacing, dashable.dashSpacing);
			}
			TransferShapeProperties();
		}

		public void Dispose()
		{
			matrices.Clear();
			initialized = false;
			drawState = default(ShapeDrawState);
			instanceCount = 0;
		}
	}
}
