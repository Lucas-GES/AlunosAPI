import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from './pages/Login';
import Alunos from './pages/Alunos';
import NovoAluno from './pages/NovoAluno';

export default function Rotas(){
    return (
        <BrowserRouter>
            <Routes>
                <Route path='/' exact Component={Login}/>
                <Route path='/alunos' Component={Alunos}/>
                <Route path='/alunos/aluno/novo/:alunoId' Component={NovoAluno}/>
            </Routes>
        </BrowserRouter>
    );
}