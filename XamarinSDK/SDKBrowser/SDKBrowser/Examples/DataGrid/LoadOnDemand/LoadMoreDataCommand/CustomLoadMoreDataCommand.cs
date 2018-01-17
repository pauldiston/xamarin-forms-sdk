﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.DataGrid;
using Telerik.XamarinForms.DataGrid.Commands;

namespace SDKBrowser.Examples.DataGrid
{
    // >> datagrid-customloadmoredatacommand-csharp
    public class CustomLoadMoreDataCommand : DataGridCommand
    {
        public CustomLoadMoreDataCommand()
        {
            this.Id = DataGridCommandId.LoadMoreData;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public async override void Execute(object parameter)
        {
            ((LoadOnDemandContext)parameter).ShowLoadOnDemandLoadingIndicator();
            
            await System.Threading.Tasks.Task.Delay(1500);
            var viewModel = this.Owner.BindingContext as LoadMoreDataCommandViewModel;
            if (viewModel != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    viewModel.Items.Add(new Person { Name = "Person " + i, Age = i + 18, Gender = i % 2 == 0 ? Gender.Male : Gender.Female });
                }
            }
            ((LoadOnDemandContext)parameter).HideLoadOnDemandLoadingIndicator();
        }
    }
    // << datagrid-customloadmoredatacommand-csharp
}