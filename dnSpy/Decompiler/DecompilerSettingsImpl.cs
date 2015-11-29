﻿/*
    Copyright (C) 2014-2015 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.ComponentModel.Composition;
using dnSpy.Contracts.Languages;
using dnSpy.Contracts.Plugin;
using dnSpy.Contracts.Settings;
using ICSharpCode.Decompiler;

namespace dnSpy.Decompiler {
	[ExportAutoLoaded(Order = double.MinValue)]
	sealed class DecompilerSettingsLoader : IAutoLoaded {
		[ImportingConstructor]
		DecompilerSettingsLoader(DecompilerSettingsImpl impl) {
			// DecompilerSettingsImpl calls DecompilationOptions.SetDecompilerSettingsFactory()
		}
	}

	[Export, Export(typeof(DecompilerSettings)), PartCreationPolicy(CreationPolicy.Shared)]
	sealed class DecompilerSettingsImpl : DecompilerSettings {
		const string SETTINGS_NAME = "6745457F-254B-4B7B-90F1-F948F0721C3B";

		readonly ISettingsManager settingsManager;

		[ImportingConstructor]
		DecompilerSettingsImpl(ISettingsManager settingsManager) {
			DecompilationOptions.SetDecompilerSettingsFactory(() => Clone());

			this.settingsManager = settingsManager;

			this.disableSave = true;
			var sect = settingsManager.GetOrCreateSection(SETTINGS_NAME);
			this.DecompilationObject0 = sect.Attribute<DecompilationObject?>("DecompilationObject0") ?? this.DecompilationObject0;
			this.DecompilationObject1 = sect.Attribute<DecompilationObject?>("DecompilationObject1") ?? this.DecompilationObject1;
			this.DecompilationObject2 = sect.Attribute<DecompilationObject?>("DecompilationObject2") ?? this.DecompilationObject2;
			this.DecompilationObject3 = sect.Attribute<DecompilationObject?>("DecompilationObject3") ?? this.DecompilationObject3;
			this.DecompilationObject4 = sect.Attribute<DecompilationObject?>("DecompilationObject4") ?? this.DecompilationObject4;
			this.AnonymousMethods = sect.Attribute<bool?>("AnonymousMethods") ?? this.AnonymousMethods;
			this.ExpressionTrees = sect.Attribute<bool?>("ExpressionTrees") ?? this.ExpressionTrees;
			this.YieldReturn = sect.Attribute<bool?>("YieldReturn") ?? this.YieldReturn;
			this.AsyncAwait = sect.Attribute<bool?>("AsyncAwait") ?? this.AsyncAwait;
			this.AutomaticProperties = sect.Attribute<bool?>("AutomaticProperties") ?? this.AutomaticProperties;
			this.AutomaticEvents = sect.Attribute<bool?>("AutomaticEvents") ?? this.AutomaticEvents;
			this.UsingStatement = sect.Attribute<bool?>("UsingStatement") ?? this.UsingStatement;
			this.ForEachStatement = sect.Attribute<bool?>("ForEachStatement") ?? this.ForEachStatement;
			this.LockStatement = sect.Attribute<bool?>("v") ?? this.LockStatement;
			this.SwitchStatementOnString = sect.Attribute<bool?>("SwitchStatementOnString") ?? this.SwitchStatementOnString;
			this.UsingDeclarations = sect.Attribute<bool?>("UsingDeclarations") ?? this.UsingDeclarations;
			this.QueryExpressions = sect.Attribute<bool?>("QueryExpressions") ?? this.QueryExpressions;
			this.FullyQualifyAmbiguousTypeNames = sect.Attribute<bool?>("FullyQualifyAmbiguousTypeNames") ?? this.FullyQualifyAmbiguousTypeNames;
			this.UseDebugSymbols = sect.Attribute<bool?>("UseDebugSymbols") ?? this.UseDebugSymbols;
			this.ObjectOrCollectionInitializers = sect.Attribute<bool?>("ObjectOrCollectionInitializers") ?? this.ObjectOrCollectionInitializers;
			this.ShowXmlDocumentation = sect.Attribute<bool?>("ShowXmlDocumentation") ?? this.ShowXmlDocumentation;
			this.ShowILComments = sect.Attribute<bool?>("ShowILComments") ?? this.ShowILComments;
			this.RemoveEmptyDefaultConstructors = sect.Attribute<bool?>("RemoveEmptyDefaultConstructors") ?? this.RemoveEmptyDefaultConstructors;
			this.IntroduceIncrementAndDecrement = sect.Attribute<bool?>("IntroduceIncrementAndDecrement") ?? this.IntroduceIncrementAndDecrement;
			this.MakeAssignmentExpressions = sect.Attribute<bool?>("MakeAssignmentExpressions") ?? this.MakeAssignmentExpressions;
			this.AlwaysGenerateExceptionVariableForCatchBlocks = sect.Attribute<bool?>("AlwaysGenerateExceptionVariableForCatchBlocks") ?? this.AlwaysGenerateExceptionVariableForCatchBlocks;
			this.ShowTokenAndRvaComments = sect.Attribute<bool?>("ShowTokenAndRvaComments") ?? this.ShowTokenAndRvaComments;
			this.ShowILBytes = sect.Attribute<bool?>("ShowILBytes") ?? this.ShowILBytes;
			this.SortMembers = sect.Attribute<bool?>("SortMembers") ?? this.SortMembers;
			this.ForceShowAllMembers = sect.Attribute<bool?>("ForceShowAllMembers") ?? this.ForceShowAllMembers;
			this.SortSystemUsingStatementsFirst = sect.Attribute<bool?>("SortSystemUsingStatementsFirst") ?? this.SortSystemUsingStatementsFirst;
			//TODO: CSharpFormattingOptions
			this.disableSave = false;
		}
		readonly bool disableSave;

		protected override void OnModified() {
			if (disableSave)
				return;
			var sect = settingsManager.RecreateSection(SETTINGS_NAME);
			sect.Attribute("DecompilationObject0", DecompilationObject0);
			sect.Attribute("DecompilationObject1", DecompilationObject1);
			sect.Attribute("DecompilationObject2", DecompilationObject2);
			sect.Attribute("DecompilationObject3", DecompilationObject3);
			sect.Attribute("DecompilationObject4", DecompilationObject4);
			sect.Attribute("AnonymousMethods", AnonymousMethods);
			sect.Attribute("ExpressionTrees", ExpressionTrees);
			sect.Attribute("YieldReturn", YieldReturn);
			sect.Attribute("AsyncAwait", AsyncAwait);
			sect.Attribute("AutomaticProperties", AutomaticProperties);
			sect.Attribute("AutomaticEvents", AutomaticEvents);
			sect.Attribute("UsingStatement", UsingStatement);
			sect.Attribute("ForEachStatement", ForEachStatement);
			sect.Attribute("LockStatement", LockStatement);
			sect.Attribute("SwitchStatementOnString", SwitchStatementOnString);
			sect.Attribute("UsingDeclarations", UsingDeclarations);
			sect.Attribute("QueryExpressions", QueryExpressions);
			sect.Attribute("FullyQualifyAmbiguousTypeNames", FullyQualifyAmbiguousTypeNames);
			sect.Attribute("UseDebugSymbols", UseDebugSymbols);
			sect.Attribute("ObjectOrCollectionInitializers", ObjectOrCollectionInitializers);
			sect.Attribute("ShowXmlDocumentation", ShowXmlDocumentation);
			sect.Attribute("ShowILComments", ShowILComments);
			sect.Attribute("RemoveEmptyDefaultConstructors", RemoveEmptyDefaultConstructors);
			sect.Attribute("IntroduceIncrementAndDecrement", IntroduceIncrementAndDecrement);
			sect.Attribute("MakeAssignmentExpressions", MakeAssignmentExpressions);
			sect.Attribute("AlwaysGenerateExceptionVariableForCatchBlocks", AlwaysGenerateExceptionVariableForCatchBlocks);
			sect.Attribute("ShowTokenAndRvaComments", ShowTokenAndRvaComments);
			sect.Attribute("ShowILBytes", ShowILBytes);
			sect.Attribute("SortMembers", SortMembers);
			sect.Attribute("ForceShowAllMembers", ForceShowAllMembers);
			sect.Attribute("SortSystemUsingStatementsFirst", SortSystemUsingStatementsFirst);
			//TODO: CSharpFormattingOptions
		}
	}
}