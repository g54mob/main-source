using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Snowflake;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Simulation
{
	public static class Circuit
	{
		public class Lead
		{
			public int toneFreq;

			public bool tone;

			public ICircuitModel elem { get; private set; }

			public int ndx { get; set; }

			public Lead(ICircuitModel e, int i)
			{
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		private struct StepJop : IJobParallelFor
		{
			[NativeDisableUnsafePtrRestriction]
			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public NativeArray<IntPtr> steps;

			public void Execute(int i)
			{
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		private struct SetLeadVoltage : IJobParallelFor
		{
			public int nmmr;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<int> nmrs;

			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public NativeArray<double> cev;

			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public NativeArray<IntPtr> lead_volts;

			public void Execute(int id)
			{
			}
		}

		public struct UnknownEntry_t
		{
			public int i;

			public int j;

			public double value;

			public UnknownEntry_t(int i, int k, double value)
			{
				this.i = 0;
				j = 0;
				this.value = 0.0;
			}
		}

		private class FindPathInfo
		{
			public enum PathType
			{
				INDUCT = 0,
				VOLTAGE = 1,
				SHORT = 2,
				CAP_V = 3
			}

			private bool[] used;

			private int dest;

			private ICircuitModel firstElm;

			private PathType type;

			public FindPathInfo(PathType t, ICircuitModel e, int d)
			{
			}

			public bool findPath(int n1)
			{
				return false;
			}

			public bool findPath(int n1, int depth)
			{
				return false;
			}
		}

		public class Exception : System.Exception
		{
			public ICircuitModel element { get; private set; }

			public Exception(string why, ICircuitModel elem)
			{
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate void KLU_Solve_pre_processedDelegate(void* B, int size, bool refactor, double rcond_tol);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void DebugCallback();

		[BurstCompile(CompileSynchronously = true)]
		private struct Decomposition : IJob
		{
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<double> matx;

			[NativeDisableContainerSafetyRestriction]
			public NativeArray<double> scale;

			[NativeDisableContainerSafetyRestriction]
			public NativeArray<int> pivot;

			[NativeDisableContainerSafetyRestriction]
			public NativeArray<double> right;

			[ReadOnly]
			public int size;

			public void Execute()
			{
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		private struct UpdateNodeMesh : IJobParallelFor
		{
			public int nlc;

			public int nmc;

			public int nMMaxRow;

			public int fullSize;

			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public NativeArray<RowInfo_t> cRI;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<double> cRs;

			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public NativeArray<long> l;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<long> nodeMesh;

			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public NativeArray<int> rowSize;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<long> nodeList;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<double> cev;

			[NativeDisableContainerSafetyRestriction]
			[NativeDisableParallelForRestriction]
			public NativeArray<double> vsc;

			public void Execute(int j)
			{
			}
		}

		public static long[][] _nodeMesh;

		public static bool Converged;

		public static int SubIterations;

		private static IdWorker snowflake;

		public static bool _analyze;

		private static double _timeStep;

		public static List<long> NodeList;

		public static ICircuitModel[] voltageSources;

		private static double[][] circuitMatrix;

		private static double[] circuitRightSide;

		private static double[][] origMatrix;

		private static double[] origRightSide;

		private static int[] circuitPermute;

		private static int circuitMatrixSize;

		private static int circuitMatrixFullSize;

		public static bool circuitNonLinear;

		public static bool circuitNeedsMap;

		private static Dictionary<ICircuitModel, List<ScopeFrame>> scopeMap;

		public static bool canTick;

		public static bool hasTick;

		public static int missFrames;

		public static ICircuitModel[] circElms;

		private unsafe static void** step_function_ptrs;

		private static JobHandle stepHandle;

		private static StepJop stepJob;

		public static int subiter;

		private static JobHandle setLeadVoltageHandle;

		private static SetLeadVoltage setLeadVoltageJob;

		private static RowInfo_t ri;

		private static int ndx;

		private static int ji;

		private static int nLcount;

		private static int nMcount;

		private static int elmCount;

		public static int matrixSize;

		private static long id;

		private static ICircuitModel gndElem;

		private static ICircuitModel vElem;

		public static bool firstUse;

		public static ICircuitModel[] convergenceElements;

		public static ICircuitModel[] nonConvergenceElements;

		private static int convElmCount;

		private static int nonConvElmCount;

		public static bool FirstFactor;

		public const double PREPROCESS_VAL = 1E-14;

		public static List<UnknownEntry_t> UnknownEntries;

		private static double[] scaleFactors;

		private static double largest;

		private static double x;

		private static double q;

		private static double mult;

		private static int largestRow;

		private static int i;

		private static int j;

		private static int k;

		private static int row;

		private static int bi;

		private static double swap;

		private static double tot;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<double> oMatx;

		[NativeDisableContainerSafetyRestriction]
		public static NativeArray<double> cMatx;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<double> oRs;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<double> circuitRS;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<double> sF;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<int> cPer;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<IntPtr> elem_lead_volts;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<IntPtr> step_functions;

		private static bool canDispose;

		private static Decomposition DecompJob;

		private static JobHandle decompHandle;

		private static JobHandle updateNodeHandle;

		public static int SolveStatus;

		private static IntPtr SolveFunctionPtr;

		public unsafe static double* RightSide;

		private unsafe static double** lead_volts_ptr;

		private unsafe static int* nmrs_ptr;

		private unsafe static double* cev_ptr;

		public static DebugCallback debugCallback;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<long> nativeNodeMesh;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<int> nodeMeshRowSize;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<RowInfo_t> circuitRowInfo;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<long> leads;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<long> _nodeList;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<double> voltSourceCurrents;

		[NativeDisableContainerSafetyRestriction]
		private static NativeArray<double> circElemVoltages;

		private static int nodeMeshMaxRow;

		private static UpdateNodeMesh nodeMeshJob;

		public static double Time { get; private set; }

		public static double TimeStep
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public static int speed { get; set; }

		public static List<ICircuitModel> elements { get; set; }

		public static List<long[]> nodeMesh { get; set; }

		public static int nodeCount => 0;

		static Circuit()
		{
		}

		public static T Create<T>(params object[] args) where T : class, ICircuitModel
		{
			return null;
		}

		public static void AddElement(ICircuitModel elm)
		{
		}

		public static void Connect(Lead left, Lead right)
		{
		}

		public static void Connect(ICircuitModel left, int leftLeadNdx, ICircuitModel right, int rightLeadNdx)
		{
		}

		public static void Connect(int leftNdx, int leftLeadNdx, int rightNdx, int rightLeadNdx)
		{
		}

		public static List<ScopeFrame> Watch(ICircuitModel component)
		{
			return null;
		}

		public static void resetTime()
		{
		}

		public static void needAnalyze()
		{
		}

		public static void UpdateVoltageSource(int n1, int n2, int vs, double v)
		{
		}

		public static long getNodeId(int ndx, int nLCount)
		{
			return 0L;
		}

		public static ICircuitModel getElm(int n)
		{
			return null;
		}

		public static void TickCall(long us = -1L)
		{
		}

		public static void ThreadTickCall(long us = -1L)
		{
		}

		public static void tick(long us)
		{
		}

		public static void analyze(Action returnCall)
		{
		}

		public static void analyze(bool keepState = false)
		{
		}

		public static void panic(string why, ICircuitModel elem)
		{
		}

		public static void StampCurrentSource(int n1, int n2, double i)
		{
		}

		public static void StampVoltageSource(int n1, int n2, int vs, double v)
		{
		}

		public static void StampVoltageSource(int n1, int n2, int vs)
		{
		}

		public static void StampResistor(int n1, int n2, double r)
		{
		}

		public static void stampConductance(int n1, int n2, double r0)
		{
		}

		public static void stampVCVS(int n1, int n2, double coef, int vs)
		{
		}

		public static void stampVCCS(int cn1, int cn2, int vn1, int vn2, double g)
		{
		}

		public static void stampCCCS(int n1, int n2, int vs, double gain)
		{
		}

		public static void stampMatrix(int i, int j, double x)
		{
		}

		public static void DefineSingleUnknown(int i, int j)
		{
		}

		public static void DefineConductanceUnknown(int i, int j)
		{
		}

		public static ConductanceStamp_t GetConductanceMatrixPointer(int i, int j)
		{
			return default(ConductanceStamp_t);
		}

		public static void StampRightSide(int i, double x)
		{
		}

		public static int GetRightSideIndex(int i)
		{
			return 0;
		}

		public static void StampRightSide(int i)
		{
		}

		public static void stampNonLinear(int i)
		{
		}

		[BurstCompile]
		public static bool lu_factor(double[][] aO, int n, int[] ipvtO)
		{
			return false;
		}

		private static double Absolute(double d)
		{
			return 0.0;
		}

		public static void lu_solve(double[][] aO, int n, int[] ipvtO, double[] bO)
		{
		}

		private static void CreateNativeArrays()
		{
		}

		public static void Dispose()
		{
		}

		private static void BurstLUFactor(bool refactor = false)
		{
		}

		[PreserveSig]
		public unsafe static extern void Decompose(void* matx, void* scale, void* pivot, void* right, int size, int threads);

		[PreserveSig]
		public unsafe static extern void KLU_Solve(void* B, int size);

		[PreserveSig]
		public unsafe static extern int KLU_Solve_pre_processed(void* B, int size, bool refactor, double rcond_tol);

		[PreserveSig]
		private static extern IntPtr KLUSolvePreProcessedPointer();

		[PreserveSig]
		public static extern void set_preprocess(bool val);

		[PreserveSig]
		public unsafe static extern void Initialise_Base_CCS(int n, double* dense_matrix);

		[PreserveSig]
		public unsafe static extern double* Insert_Value_CCS(int row, int col, double value);

		[PreserveSig]
		public static extern void Initialise_Working_CSS();

		[PreserveSig]
		public unsafe static extern double* Set_right_side(double* ptr);

		[PreserveSig]
		public unsafe static extern void Set_row_info(RowInfo_t* ptr);

		[PreserveSig]
		public static extern StampMatrixPtr_t Stamp_Matrix(int i, int j, double x, bool need_map = true);

		[PreserveSig]
		public unsafe static extern void Create_node_mesh_map(int nlc, int nmc, int nMMaxRow, ulong fullSize, RowInfo_t* cRI, double* cRs, long* l, long* nodeMesh, int* rowSize, long* nodeList, double* cev, double* vsc);

		[PreserveSig]
		public unsafe static extern void Update_node_mesh(int nlc, int nmc, int nMMaxRow, ulong fullSize, RowInfo_t* cRI, double* cRs, long* l, long* nodeMesh, int* rowSize, long* nodeList, double* cev, double* vsc);

		[PreserveSig]
		public unsafe static extern void Update_node_mesh_from_map(ulong fullSize, RowInfo_t* cRI, double* cRs, double* cev, double* vsc);

		[PreserveSig]
		public unsafe static extern void Set_lead_voltages(ulong len, int nmmr, int* nmrs, double* cev, double** lead_volts);

		[PreserveSig]
		public unsafe static extern void step_function(ulong len, void** step_func_ptrs);

		[PreserveSig]
		public static extern void Stamp_right_side(int i, double x, bool need_map);

		[PreserveSig]
		public static extern void stamp_conductance_cpp(int n, int n1, int n2, double r0, bool need_map);

		[PreserveSig]
		public static extern void stamp_resistor_cpp(int n, int n1, int n2, double r0, bool need_map);

		[PreserveSig]
		public static extern void stamp_current_source_cpp(int n1, int n2, double i, bool need_map);

		[PreserveSig]
		public static extern void register_value_inserted_callback(IntPtr callback);

		[PreserveSig]
		public static extern void Stamp_Matrix_Direct(int i, double x);

		[PreserveSig]
		public static extern int PP_Stamp_Matrix(int n, int i, int j, double x, bool need_map);

		[PreserveSig]
		public unsafe static extern void Stamp_Original_Matrix(int i, int j, double x, double* right_side);

		[PreserveSig]
		public static extern void stamp_conductance_direct(ref Conductance_t ids, double x);

		[PreserveSig]
		public static extern Conductance_t PP_stamp_conductance_cpp(int n, int n1, int n2, double r0, bool need_map);

		[PreserveSig]
		public static extern void stamp_resistor_direct(ref Conductance_t ids, double x);

		[PreserveSig]
		public static extern Conductance_t PP_stamp_resistor_cpp(int n, int n1, int n2, double r, bool need_map);

		[PreserveSig]
		public static extern SingleStamp_t GetSingleMatrixPointer(int i, int j);
	}
}
