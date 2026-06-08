using System.Collections.Generic;
using Antlr4.Runtime;
using Stonescript;
using Stonescript.Compiler;
using Stonescript.Runtime;

public class InvocationContext
{
	public Executable executable;

	public ExecutionContext execCtx;

	public Script script;

	public IFunction function;

	public List<object> parameters;

	public Machine machine;

	public Processor processor;

	public StonescriptObject owner;

	public Scope scope;

	public InvocationContext parent;

	public RuleContext node;

	public StonescriptObject target;

	public string ScriptName => executable.script.name;

	public int LineNumber => execCtx.LineNumber;

	public InvocationContext()
	{
		Init();
	}

	public InvocationContext Init()
	{
		return this;
	}

	public InvocationContext(ExecutionContext execCtx, Scope scope)
	{
		Init(execCtx, scope);
	}

	public InvocationContext Init(ExecutionContext execCtx, Scope scope)
	{
		this.execCtx = execCtx;
		machine = execCtx.machine;
		processor = execCtx.processor;
		this.scope = scope;
		owner = scope;
		target = scope;
		return this;
	}

	public InvocationContext(ExecutionContext execCtx, StonescriptObject target, IFunction function, List<object> parameters, Scope scope)
	{
		Init(execCtx, target, function, parameters, scope);
	}

	public InvocationContext Init(ExecutionContext execCtx, StonescriptObject target, IFunction function, List<object> parameters, Scope scope)
	{
		this.execCtx = execCtx;
		machine = execCtx.machine;
		processor = execCtx.processor;
		this.function = function;
		this.parameters = parameters;
		owner = target;
		this.target = target;
		this.scope = scope;
		return this;
	}

	public void Reset()
	{
		executable = null;
		execCtx = null;
		script = null;
		function = null;
		parameters = null;
		machine = null;
		processor = null;
		owner = null;
		target = null;
		scope = null;
		parent = null;
		node = null;
	}
}
