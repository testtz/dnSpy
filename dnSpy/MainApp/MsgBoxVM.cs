﻿/*
    Copyright (C) 2014-2016 de4dot@gmail.com

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

using System;
using System.Windows.Input;
using dnSpy.Contracts.App;
using dnSpy.Shared.MVVM;

namespace dnSpy.MainApp {
	sealed class MsgBoxVM : ViewModelBase {
		public ICommand OKCommand {
			get { return new RelayCommand(a => listener(MsgBoxButton.OK)); }
		}

		public ICommand YesCommand {
			get { return new RelayCommand(a => listener(MsgBoxButton.Yes)); }
		}

		public ICommand NoCommand {
			get { return new RelayCommand(a => listener(MsgBoxButton.No)); }
		}

		public ICommand CancelCommand {
			get { return new RelayCommand(a => listener(MsgBoxButton.Cancel)); }
		}

		public string Message {
			get { return message; }
		}
		readonly string message;

		public bool DontShowAgain {
			get { return dontShowAgain; }
			set {
				if (dontShowAgain != value) {
					dontShowAgain = value;
					OnPropertyChanged("DontShowAgain");
				}
			}
		}
		bool dontShowAgain;

		public bool HasDontShowAgain {
			get { return hasDontShowAgain; }
			set {
				if (hasDontShowAgain != value) {
					hasDontShowAgain = value;
					OnPropertyChanged("HasDontShowAgain");
				}
			}
		}
		bool hasDontShowAgain;

		public bool HasOKButton {
			get { return hasOKButton; }
			set {
				if (hasOKButton != value) {
					hasOKButton = value;
					OnPropertyChanged("HasOKButton");
				}
			}
		}
		bool hasOKButton;

		public bool HasYesButton {
			get { return hasYesButton; }
			set {
				if (hasYesButton != value) {
					hasYesButton = value;
					OnPropertyChanged("HasYesButton");
				}
			}
		}
		bool hasYesButton;

		public bool HasNoButton {
			get { return hasNoButton; }
			set {
				if (hasNoButton != value) {
					hasNoButton = value;
					OnPropertyChanged("HasNoButton");
				}
			}
		}
		bool hasNoButton;

		public bool HasCancelButton {
			get { return hasCancelButton; }
			set {
				if (hasCancelButton != value) {
					hasCancelButton = value;
					OnPropertyChanged("HasCancelButton");
				}
			}
		}
		bool hasCancelButton;

		readonly Action<MsgBoxButton> listener;

		public MsgBoxVM(string message, Action<MsgBoxButton> listener) {
			this.message = message;
			this.listener = listener;
		}
	}
}
