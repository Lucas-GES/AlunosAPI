import React from "react";
import { Link } from "react-router-dom";
import "./styles.css";
import { FiEdit, FiUserX, FiXCircle } from "react-icons/fi";
import logoCadastro from "../../assets/cadastro.png";

export default function Alunos() {
    return (
        <div className="aluno-container">
            <header>
                <img src={logoCadastro} alt="Cadastro" />
                <span>
                    Bem-Vindo, <strong>Luck</strong>!
                </span>
                <Link className="button" to="aluno/novo/0">
                    Novo Aluno
                </Link>
                <button type="button">
                    <FiXCircle size={35} color="#17202a" />
                </button>
            </header>
            <form>
                <input type="text" placeholder="Nome" />
                <button type="button" className="button">
                    Filtrar aluno por nome (parcial)
                </button>
            </form>
            <h1>Relação de Alunos</h1>
            <ul>
                <li>
                    <b>Nome:</b>Luck<br /><br />
                    <b>Email:</b>luck@email.com<br /><br />
                    <b>Idade:</b>27<br /><br />
                    <button type="button">
                        <FiEdit size="25" color="#17202a"/>
                    </button>
                    <button type="button">
                        <FiUserX size="25" color="#17202a"/>
                    </button>
                </li>
                <li>
                    <b>Nome:</b>Luck<br /><br />
                    <b>Email:</b>luck@email.com<br /><br />
                    <b>Idade:</b>27<br /><br />
                    <button type="button">
                        <FiEdit size="25" color="#17202a"/>
                    </button>
                    <button type="button">
                        <FiUserX size="25" color="#17202a"/>
                    </button>
                </li>
            </ul>
        </div>
    );
}
