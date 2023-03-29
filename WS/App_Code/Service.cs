using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.DynamicData;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	SqlConnection connection = new SqlConnection("server=LIS16_3\\SQLEXPRESS ; database=MYDB ; integrated security = true");

    public DataSet Get_User(int id)
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand("SP_get_user", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("id", SqlDbType.Int).Value = id;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(ds, "users");

        return ds;
    }

    public DataSet Get_Users() { 
		DataSet ds = new DataSet();
		SqlDataAdapter sda = new SqlDataAdapter("SP_get_users", connection);
		sda.Fill(ds, "users");
		return ds;
	}

    public void Insert_User(User user)
    {	
		connection.Open();
        SqlCommand cmd = new SqlCommand("SP_insert_user", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("name", SqlDbType.Text).Value = user.Name;
        cmd.Parameters.Add("birthdate", SqlDbType.DateTime).Value = user.Birthdate;
        cmd.Parameters.Add("sex", SqlDbType.Text).Value = user.Sex;

		try
		{
			cmd.ExecuteNonQuery();
		}
		catch (Exception)
		{

			throw;
		}

    }

    public void Delete_User(int id)
    {
        connection.Open();
        SqlCommand cmd = new SqlCommand("SP_delete_user", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("id", SqlDbType.Int).Value = id;
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {

            throw;
        }

    }

    public void Update_User(User user)
    {
        connection.Open();
        SqlCommand cmd = new SqlCommand("SP_update_user", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("id", SqlDbType.Int).Value = user.Id;
        cmd.Parameters.Add("name", SqlDbType.Text).Value = user.Name;
        cmd.Parameters.Add("birthdate", SqlDbType.DateTime).Value = user.Birthdate;
        cmd.Parameters.Add("sex", SqlDbType.Text).Value = user.Sex;

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {

            throw;
        }

    }

}
