/* Title:           Projects Class
 * Date:            5-4-16
 * Author:          Terry Holmes
 *
 * Description:     This class is to create the projects */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace ProjectsDLL
{
    public class ProjectClass
    {
        //setting up the class
        EventLogClass TheEventLogClass = new EventLogClass();

        ProjectsDataSet aProjectsDataSet;
        ProjectsDataSetTableAdapters.projectsTableAdapter aProjectsTableAdapter;

        FindProjectByAssignedProjectIDDataSet aFindProjectByAssignedProjectIDDataSet;
        FindProjectByAssignedProjectIDDataSetTableAdapters.FindProjectByAssignedProjectIDTableAdapter aFindProjectByAssignedProjectIDTableAdapter;

        FindProjectByProjectIDDataSet aFindProjectByProjectIDDataSet;
        FindProjectByProjectIDDataSetTableAdapters.FindProjectByProjectIDTableAdapter aFindProjectByProjectIDTableAdpater;

        FindProjectByProjectNameDataSet aFindProjectByProjectNameDataSet;
        FindProjectByProjectNameDataSetTableAdapters.FindProjectByProjectNameTableAdapter aFindProjectByProjectNameTableAdpater;

        InsertProjectDataTableAdapters.QueriesTableAdapter aInsertProjectDataTableAdapter;

        UpdateProjectDataTableAdapters.QueriesTableAdapter aUpdateProjectTableAdapter;

        FindProjectsByDateRangeDataSet aFindProjectsByDateRangeDataSet;
        FindProjectsByDateRangeDataSetTableAdapters.FindProjectsByDateRangeTableAdapter aFindProjectsByDateRangeTableAdapter;

        RemoveProjectEntryTableAdapters.QueriesTableAdapter aRemoveProjectEntryTableAdapter;

        public bool RemoveProjectEntry(int intProjectID)
        {
            bool blnFatalError = false;

            try
            {
                aRemoveProjectEntryTableAdapter = new RemoveProjectEntryTableAdapters.QueriesTableAdapter();
                aRemoveProjectEntryTableAdapter.RemoveProjects(intProjectID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Projects Class // Remove Project Entry " + Ex.Message);
            }

            return blnFatalError;
        }
        public FindProjectsByDateRangeDataSet FindProjectsByDateRange(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindProjectsByDateRangeDataSet = new FindProjectsByDateRangeDataSet();
                aFindProjectsByDateRangeTableAdapter = new FindProjectsByDateRangeDataSetTableAdapters.FindProjectsByDateRangeTableAdapter();
                aFindProjectsByDateRangeTableAdapter.Fill(aFindProjectsByDateRangeDataSet.FindProjectsByDateRange, datStartDate, datEndDate);
            }
            catch(Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Projects Class // Find Projects By Date Range " + Ex.Message);
            }

            return aFindProjectsByDateRangeDataSet;
        }
        public bool UpdateProjectProject(int intProjectID, string strAssignedProjectID, string strProjectName)
        {
            bool blnFatalError = false;
            
            try
            {
                aUpdateProjectTableAdapter = new UpdateProjectDataTableAdapters.QueriesTableAdapter();
                aUpdateProjectTableAdapter.UpdateProject(intProjectID, strAssignedProjectID, strProjectName);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Project Class // Update Project " + Ex.Message);
            }

            return blnFatalError;
        }
        public bool InsertProject(string strAssignedProjectID, string strProjectName)
        {
            bool blnFatalError = false;
            int intProjectID = 1000;
            
            try
            {
                aInsertProjectDataTableAdapter = new InsertProjectDataTableAdapters.QueriesTableAdapter();
                aInsertProjectDataTableAdapter.InsertProject(intProjectID, strAssignedProjectID, strProjectName, DateTime.Now);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Project Class // Insert Project " + Ex.Message);
            }

            return blnFatalError;
        }
        public FindProjectByProjectNameDataSet FindProjectByProjectName(string strProjectName)
        {
            try
            {
                aFindProjectByProjectNameDataSet = new FindProjectByProjectNameDataSet();
                aFindProjectByProjectNameTableAdpater = new FindProjectByProjectNameDataSetTableAdapters.FindProjectByProjectNameTableAdapter();
                aFindProjectByProjectNameTableAdpater.Fill(aFindProjectByProjectNameDataSet.FindProjectByProjectName, strProjectName);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Project Class // Find Project By Project Name " + Ex.Message);
            }

            return aFindProjectByProjectNameDataSet;
        }
        public FindProjectByProjectIDDataSet FindProjectByProjectID(int intProjectID)
        {
            try
            {
                aFindProjectByProjectIDDataSet = new FindProjectByProjectIDDataSet();
                aFindProjectByProjectIDTableAdpater = new FindProjectByProjectIDDataSetTableAdapters.FindProjectByProjectIDTableAdapter();
                aFindProjectByProjectIDTableAdpater.Fill(aFindProjectByProjectIDDataSet.FindProjectByProjectID, intProjectID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Projects Class // Find Project By Project ID " + Ex.Message);
            }

            return aFindProjectByProjectIDDataSet;
        }
        public FindProjectByAssignedProjectIDDataSet FindProjectByAssignedProjectID(string strAssignedProjectID)
        {
            try
            {
                aFindProjectByAssignedProjectIDDataSet = new FindProjectByAssignedProjectIDDataSet();
                aFindProjectByAssignedProjectIDTableAdapter = new FindProjectByAssignedProjectIDDataSetTableAdapters.FindProjectByAssignedProjectIDTableAdapter();
                aFindProjectByAssignedProjectIDTableAdapter.Fill(aFindProjectByAssignedProjectIDDataSet.FindProjectByAssignedProjectID, strAssignedProjectID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Projects Class // Find Project By Assigned Project ID " + Ex.Message);
            }

            return aFindProjectByAssignedProjectIDDataSet;
        }
        public ProjectsDataSet GetProjectsInfo()
        {
            try
            {
                aProjectsDataSet = new ProjectsDataSet();
                aProjectsTableAdapter = new ProjectsDataSetTableAdapters.projectsTableAdapter();
                aProjectsTableAdapter.Fill(aProjectsDataSet.projects);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Project Class // Get Projects Info " + Ex.Message);
            }

            return aProjectsDataSet;
        }
        public void UpdateProjectsDB(ProjectsDataSet aProjectsDataSet)
        {
            try
            { 
                aProjectsTableAdapter = new ProjectsDataSetTableAdapters.projectsTableAdapter();
                aProjectsTableAdapter.Update(aProjectsDataSet.projects);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Project Class // Get Projects Info " + Ex.Message);
            }
        }
    }
}
