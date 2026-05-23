using app;
using app.vis;
using data;
using haxe.ds;
using haxe.lang;
using play.stash;

namespace play.day
{
	public class BoothEnv : HxObject
	{
		public static int kTranscriptLinesPerPage;

		public BoothEnvRun run;

		public Traveler traveler;

		public List appliedErrors;

		public Rand rand;

		public Array factGroups;

		public Array invalidFactPaths;

		public StringMap paperInfos;

		public StringMap invalidFactInfos;

		public int invalidFactInfoOrder;

		public StringMap confusingFactPaths;

		public FactSet facts;

		public Array transcriptFactPaths;

		public Day day;

		public ErrorMaker errorMaker;

		public Array hadPaperIds;

		public Array clearedConfusionPaths;

		static BoothEnv()
		{
		}

		public BoothEnv(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BoothEnv(BoothEnvRun run_, Day day_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_BoothEnv(BoothEnv __hx_this, BoothEnvRun run_, Day day_)
		{
		}

		public double get_nowDate()
		{
			return 0.0;
		}

		public virtual StashedBoothEnv makeStash()
		{
			return null;
		}

		public virtual bool restoreFromStash(StashedBoothEnv s)
		{
			return false;
		}

		public virtual void addBulletinForDay()
		{
		}

		public virtual void makeNewTraveler()
		{
		}

		public virtual void clearTraveler()
		{
		}

		public virtual void applyError(Error error)
		{
		}

		public virtual int getNextMultiPaperIndex(string paperId)
		{
			return 0;
		}

		public virtual void addPaper(string paperId)
		{
		}

		public virtual Array getStayingPaperIds()
		{
			return null;
		}

		public virtual void saveStayingPaperIds()
		{
		}

		public virtual ActionResult applyOp(Op op)
		{
			return null;
		}

		public virtual int getTranscriptPageCount()
		{
			return 0;
		}

		public virtual Fact setFactValue(string path, FactValue value)
		{
			return null;
		}

		public string getFactValueText(string path, string defaultText)
		{
			return null;
		}

		public FactValue getFactValue(string path)
		{
			return null;
		}

		public virtual void setFactInvalid(string path, Op op)
		{
		}

		public virtual void setFactValid(string path)
		{
		}

		public virtual Array getPaperIdWithIndexes()
		{
			return null;
		}

		public virtual bool hasPaper(string paperId)
		{
			return false;
		}

		public virtual bool hadPaper(string paperId)
		{
			return false;
		}

		public virtual string findInvalidFactPath(string path)
		{
			return null;
		}

		public bool isValid(string path)
		{
			return false;
		}

		public virtual bool getPaperIsVisible(string paperId)
		{
			return false;
		}

		public bool wantHardError(object chance)
		{
			return false;
		}

		public virtual FactValue makeFactValue(string path, bool valid, object confusing)
		{
			return null;
		}

		public virtual Op getOpForInvalidFactPaths(Array inspectingFactPaths)
		{
			return null;
		}

		public virtual bool debugIsErrorRelatedFactPath(string inspectingFactPath)
		{
			return false;
		}

		public string getRemappedFactId(string factId)
		{
			return null;
		}

		public virtual string getLocalizedText(string paperId, string factId)
		{
			return null;
		}

		public virtual Array debugGetInvalidFactPaths()
		{
			return null;
		}

		public virtual Op debugGetInvalidFactPathOp(string invalidFactPath)
		{
			return null;
		}

		public virtual void traceAllFacts()
		{
		}

		public virtual string getDebugDescriptionForFactPath(string factPath, string indent)
		{
			return null;
		}

		public virtual string getCiteText()
		{
			return null;
		}

		public virtual bool hasErrors(object debugIncludingUnnoticableErrors)
		{
			return false;
		}

		public virtual bool testExpression(string exp)
		{
			return false;
		}

		public virtual string expandExpressionLhs(string lhs)
		{
			return null;
		}

		public virtual string getTranscriptFactPath(string markFactId)
		{
			return null;
		}

		public virtual string getFactPathForInnerVisual(PaperDef paperDef, string idWithIndex, int pageIndex, string markName)
		{
			return null;
		}

		public virtual string getPaperNameInFiler(string paperIdWithIndex)
		{
			return null;
		}

		public virtual FactRelationship getFactRelationship(string pathA, string pathB)
		{
			return null;
		}

		public virtual Image getImage(string paperId, string factId, double scale, int textColor, int backColor)
		{
			return null;
		}

		public virtual EmblemStatus getEmblemStatus(string paperId, string factId)
		{
			return null;
		}

		public virtual double debugGetPaperExpirationDate(string paperId)
		{
			return 0.0;
		}

		public virtual Speech getSpeech(string responseId, string overrideFactPath)
		{
			return null;
		}

		public virtual string expandComplexVars(string text)
		{
			return null;
		}

		public virtual Array getDefaultRunOps(string opId)
		{
			return null;
		}

		public virtual object findDefaultRunOpNode(Node node, string opId)
		{
			return null;
		}

		public virtual bool canPutInFiler(string paperId)
		{
			return false;
		}

		public virtual bool wantConfiscatePassport()
		{
			return false;
		}

		public virtual bool autoCanInspectFactPath(string factPath)
		{
			return false;
		}

		public virtual bool autoGetFactPathIsMissingEmblem(string factPath)
		{
			return false;
		}

		public virtual Array autoGetInspectableErrorPairs()
		{
			return null;
		}

		public virtual object autoGetPaperIdAndPageIndexWithFactPath(string factPath)
		{
			return null;
		}

		public virtual int autoGetPageIndexWithLink(string paperId, string link)
		{
			return 0;
		}

		public virtual bool autoGetWantConfiscatePassport(int numObristanPassportsWanted)
		{
			return false;
		}

		public override double __hx_setField_f(string field, int hash, double value, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
