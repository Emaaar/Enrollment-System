using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;


namespace april30
{
    public class StudentDatabase
    {
        readonly SQLiteAsyncConnection database;

        public StudentDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Student>().Wait();
        }

        public Task<List<Student>> GetStudentsAsync()
        {
            return database.Table<Student>().ToListAsync();
        }

        public Task<Student> GetStudentAsync(int id)
        {
            return database.Table<Student>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveStudentAsync(Student student)
        {
            if (student.Id != 0)
            {
                return database.UpdateAsync(student);
            }
            else
            {
                return database.InsertAsync(student);
            }
        }
    }
}