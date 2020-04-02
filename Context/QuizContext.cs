﻿using Microsoft.EntityFrameworkCore;
using Quiz_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_Backend.Context
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options):base(options)
        {

        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
    }
}
